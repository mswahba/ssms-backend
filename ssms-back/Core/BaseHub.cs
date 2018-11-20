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
    private BaseService _service;
    private Dictionary<string, object> _deleteResult;
    private string _tableName;
    private string _keyName;
    private string _sqlAddCommand;
    private string _columnNames;
    private string _columnValues;
    private string _clientMethod;
    public BaseHub(BaseService service, string tableName, string keyName)
    {
      _service = service;
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
    public async Task Add(TEntity entity)
    {
      _clientMethod = "Added";
      try
      {
        // if autoId has value [ok] then generate newId and set keyName of this entity
        // otherwise the entity keyField [PK] has value [from User Input]
        if (entity.GetValue(_keyName).ToString() == "0")
        {
          // get the comma separated column names
          _columnNames = entity.GetPrimitivePropsNames();
          // get the comma separated column values
          // note: key column value replaced with the sql variable [@newId]
          // which will be fulfilled before executing the insert statement
          _columnValues = entity.GetPrimitivePropsValues();
          // build SQL Command that:
          // (1) get the max key value from entity table
          // (2) If it is = null then set it = 0
          // (3) increment it by one
          // (4) insert the entity with its values
          // (5) select the previously inserted entity
          _sqlAddCommand = $@"
            Declare @newId int;
            set @newId = (select max({_keyName}) from {_tableName});
            if @newId is null set @newId = 0;
            set @newId = @newId + 1;
            insert into {_tableName} ({_columnNames}) values ({_columnValues});
            select * from {_tableName} where {_keyName} = @newId;
          ";
          Console.WriteLine(_sqlAddCommand);
          // execute SQL Command and return its value
          entity = _service.Add<TEntity>(_sqlAddCommand);
        }
        else
        {
          // add entity and saveChanges
          _service.Add<TEntity>(entity);
        }
        // if everything is ok, return the full user obj with all inserted values
        await Clients.All.SendAsync(_clientMethod, new Response<TEntity>() { Data = entity });
      }
      catch (Exception ex)
      {
        await Clients.All.SendAsync(_clientMethod, new Response<Exception>() { Exception = ex });
      }
    }
    // Update an entity to DB
    public async Task Update(TEntity entity)
    {
      _clientMethod = "Updated";
      try
      {
        _service.Update<TEntity>(entity);
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
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Must supply both newKey and oldKey ..." });
      try
      {
        // update entity Key in DB
        _service.UpdateKey(_tableName, _keyName, newKey, oldKey);
        // get the updatedKey entity
        TEntity entity = _service.GetOne<TEntity>(item => item.GetValue(_keyName).Equals(newKey));
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
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Can't identify The type of the Delete operation ..." });
      else if (key == null && entity == null)
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Must supply either key OR entity ..." });
      else if (key != null)
        entity = _service.Find<TEntity,TKey>(key);
      // if entity that comes from DB is null
      if (entity == null)
        await Clients.All.SendAsync(_clientMethod, new Response<String>() { Error = "Item doesn't exist ..." });
      await DoDelete(deleteType, entity);
    }

  }
}