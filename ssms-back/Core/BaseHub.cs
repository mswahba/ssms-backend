using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SSMS.EntityModels;
using Microsoft.AspNetCore.SignalR;

namespace SSMS
{
  public class BaseHub<TEntity, TKey> : Hub where TEntity : class
  {
    private BaseService<TEntity, TKey> _service;
    private Dictionary<string, object> _deleteResult;
    private Ado _ado;
    private string _tableName;
    private string _keyName;
    private string _selectMaxId;
    private string _clientMethod;
    public BaseHub(BaseService<TEntity, TKey> service, string tableName, string keyName, Ado ado)
    {
      _service = service;
      _ado = ado;
      _tableName = tableName;
      _keyName = keyName;
    }

    private void SetDeleteResult(TEntity entity, int res, string deleteType)
    {
      _deleteResult = new Dictionary<string, object>();
      _deleteResult.Add(_keyName, entity.GetValue(_keyName));
      _deleteResult.Add("DeleteType", deleteType);
      _deleteResult.Add("Message", $"{res} Item(s) Deleted successfully...");
    }
    private async Task DoDelete(string deleteType, TEntity entity)
    {
      // switch on the [deleteType] and perform the appropriate action
      int res;
      try
      {
        switch (deleteType)
        {
          case "logical":
            res = _service.DeleteLogical(entity);
            if (res == -1)
              await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Can't delete this Item Logically" });
            else if (res == -2)
              await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Item has already been Logically deleted before" });
            SetDeleteResult(entity, res, "logical");
            await Clients.All.SendAsync(_clientMethod, _deleteResult);
            break;
          case "physical":
            res = _service.Delete(entity);
            SetDeleteResult(entity, res, "physical");
            await Clients.All.SendAsync(_clientMethod, _deleteResult);
            break;
          default:
            await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Unknow Delete Type" });
            break;
        }
      }
      catch (Exception ex)
      {
        await Clients.All.SendAsync(_clientMethod, ex);
      }
    }

    // Add an entity to DB
    public async Task Add(string autoId, TEntity entity)
    {
      _clientMethod = "Added";
      // get newId sql select statement
      _selectMaxId = $"Declare @v_id int;" +
                      "set @v_id = (select max(" + _keyName + ") from " + _tableName + ");" +
                      "if @v_id is null set @v_id = 0;" +
                      "set @v_id = @v_id + 1;select @v_id;";
      try
      {
        // if autoId has value [ok] then generate newId and set keyName of this entity
        // otherwise the entity keyField [PK] has value [from User Input]
        if (!String.IsNullOrEmpty(autoId))
          entity.SetValue(_keyName, _ado.ExecuteScalar(_selectMaxId));
        // model state errors
        // if (!ModelState.IsValid)
        //   return BadRequest(ModelState);
        // add entity and saveChanges
        _service.Add(entity);
        // if everything is ok, return the full user obj with all inserted values
        await Clients.All.SendAsync(_clientMethod, new Response<TEntity>() { Data = entity } );
      }
      catch (Exception ex)
      {
        await Clients.All.SendAsync(_clientMethod, new Response<Exception>() { Exception = ex } );
      }
    }
    // Update an entity to DB
    public async Task Update(TEntity entity)
    {
      _clientMethod = "Updated";
      try
      {
        _service.Update(entity);
        // if everything is ok, return the full obj with all inserted values
        await Clients.All.SendAsync(_clientMethod, new Response<TEntity>() { Data = entity });
      }
      catch (Exception ex)
      {
        await Clients.All.SendAsync(_clientMethod, new Response<Exception>() { Exception = ex });
      }
    }
    // update Only an entity PK -- [Used by Admins Only]
    public async Task UpdateKey(TKey newKey, TKey oldKey)
    {
      _clientMethod = "UpdatedKey";
      // if method params are null return error
      if (newKey == null || oldKey == null)
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Must supply both newKey and oldKey ..." } );
      try
      {
        // update entity Key in DB
        _service.UpdateKey(_tableName, _keyName, newKey, oldKey);
        // get the updatedKey entity
        TEntity entity = _service.GetOne(item => item.GetValue(_keyName).Equals(newKey));
        // if everything is ok, return the full user obj with all inserted values
        await Clients.All.SendAsync(_clientMethod, new Response<TEntity>() { Data = entity });
      }
      catch (Exception ex)
      {
        await Clients.All.SendAsync(_clientMethod, new Response<Exception>() { Exception = ex });
      }
    }
    // Method which receive deleteType (logical or physical)
    // and [entityKey OR entity] to be deleted
    // if entityKey was given then get the entity by its key
    // Then call the appropriate function from the BaseService class to execute operation
    public async Task Delete(string deleteType, TKey key, TEntity entity)
    {
      _clientMethod = "Deleted";
      if (deleteType == null)
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Can't identify The type of the Delete operation ..." } );
      else if (key == null && entity == null)
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Must supply either key OR entity ..." });
      else if (key != null)
        entity = _service.GetOne(key);
      // if entity that comes from DB is null
      if (entity == null)
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Item doesn't exist ..." });
      await DoDelete(deleteType, entity);
    }

  }
}