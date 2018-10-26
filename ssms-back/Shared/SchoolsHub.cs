using System;
using System.Linq;
using SSMS.EntityModels;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SSMS.Shared
{
  public class SchoolsHub : Hub
  {
    private BaseService<School, Byte> _SchoolSrv { get; }
    public SchoolsHub(BaseService<School, Byte> service)
    {
      _SchoolSrv = service;
    }
    public async Task SendMessage(string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", message);
    }
    public async Task SendList(string listType, int? pageSize, int? pageNumber)
    {
      string clientMethod = "ReceiveList";
      //if list type doesn't match these three acceptable values (all/deleted/existing)
      //return bad request
      if (listType.ToLower() != "existing" &&
          listType.ToLower() != "deleted" &&
          listType.ToLower() != "all")
        await Clients.All.SendAsync(clientMethod, new Error() { Message = "Unknow List Type.[all] OR [deleted] OR [existing] only acceptable" });
      //If page size & number aren't provided from the query string
      //then return regular result based on list type.
      IQueryable<School> result;
      try
      {
        switch (listType.ToLower())
        {
          case "existing":
            result = _SchoolSrv.GetQuery(item =>
               item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                          ? true
                          : false
           );
            break;
          case "deleted":
            result = _SchoolSrv.GetQuery(item =>
              item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                         ? false
                         : true
           );
            break;
          case "all":
            result = _SchoolSrv.GetQuery();
            break;
          default:
            result = _SchoolSrv.GetQuery();
            break;
        }
        // if page size and number are provided, return page result  (from GetPage())
        if (pageSize != null && pageNumber != null)
        {
          var pageResult = _SchoolSrv.GetPageResult(result, (int)pageSize, (int)pageNumber);
          await Clients.All.SendAsync(clientMethod, pageResult);
        }
        await Clients.All.SendAsync(clientMethod, result);

      }
      catch (System.Exception ex)
      {
        await Clients.All.SendAsync(clientMethod, ex);
      }
    }

  }
}