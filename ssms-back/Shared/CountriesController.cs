using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Shared
{
    public class CountriesController : BaseController<Country,Byte>
    {
        private BaseService _service;
        //in ctor take parent service from DI and pass it to the base controller
        //when sending this entity type and its key type,
        //we tranform the Base service to this entity service (parent)
        public CountriesController(BaseService service, Ado ado)
                                :base(service, "countries", "countryId", ado)
        {
            _service = service;
        }
    }
}
