using System;
using System.Linq;
using SSMS.EntityModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SSMS.Hubs
{
  public class ParentsHub : BaseHub<Parent, String>
  {
    private BaseService<Parent, String> _ParentSrv;
    // in constructor take BaseService from DI
    // and setting its [TEntity,TKey] to [Parent, String] to Act as parentsService
    // and take ado object from DI [used in Auto Generate New Ids in Add Method]
    // finally pass SQL [TableName, PK ColumnName] to BaseHub
    public ParentsHub(BaseService<Parent, String> parentsService, Ado ado)
                            : base(parentsService, "parents", "parentId", ado)
    {
      _ParentSrv = parentsService;
    }
  }
}
