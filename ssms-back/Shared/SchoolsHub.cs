using System;
using System.Linq;
using SSMS.EntityModels;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SSMS
{
  public class SchoolsHub : BaseHub<School, Byte>
  {
    private BaseService<School, Byte> _SchoolSrv;
    // in constructor take BaseService from DI
    // and setting its [TEntity,TKey] to [School, Byte] to Act as schoolsService
    // and take ado object from DI [used in Auto Generate New Ids in Add Method]
    // finally pass SQL [TableName, PK ColumnName] to BaseHub
    public SchoolsHub(BaseService<School, Byte> schoolsService, Ado ado)
                            : base(schoolsService, "schools", "SchoolId", ado)
    {
      _SchoolSrv = schoolsService;
    }
  }
}