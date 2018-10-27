using System;
using System.Linq;
using SSMS.EntityModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SSMS
{
  // Inherit from BaseHub to get all the Methods inside it into the UsersHub
  public class UsersHub : BaseHub<User, String>
  {
    private BaseService<User, String> _UserSrv;
    // in constructor take BaseService from DI
    // and setting its [TEntity,TKey] to [User, String] to Act as usersService
    // and take ado object from DI [used in Auto Generate New Ids in Add Method]
    // finally pass SQL [TableName, PK ColumnName] to BaseHub
    public UsersHub(BaseService<User, String> usersService, Ado ado)
                        : base(usersService, "users", "userId", ado)
    {
      _UserSrv = usersService;
    }
  }
}
