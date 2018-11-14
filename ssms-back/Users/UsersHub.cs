using System;
using System.Linq;
using SSMS.EntityModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SSMS.Hubs
{
  // Inherit from BaseHub to get all the Methods inside it into the UsersHub
  public class UsersHub : BaseHub<User, String>
  {
    private BaseService _service;
    // in constructor take BaseService from DI
    // and setting its [TEntity,TKey] to [User, String] to Act as usersService
    // and take ado object from DI [used in Auto Generate New Ids in Add Method]
    // finally pass SQL [TableName, PK ColumnName] to BaseHub
    public UsersHub(BaseService service, Ado ado)
                        : base(service, "users", "userId", ado)
    {
      _service = service;
    }
  }
}
