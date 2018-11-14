using System;
using System.Linq;
using SSMS.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSMS.Hubs
{
  public class CountriesHub : BaseHub<Country, Byte>
  {
    private BaseService _service;
    // in constructor take BaseService from DI
    // and setting its [TEntity,TKey] to [Country, Byte] to Act as countriesService
    // and take ado object from DI [used in Auto Generate New Ids in Add Method]
    // finally pass SQL [TableName, PK ColumnName] to BaseHub
    public CountriesHub(BaseService service, Ado ado)
                            : base(service, "countries", "countryId", ado)
    {
      _service = service;
    }
  }
}
