using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Shared
{
    public class SchoolsController : BaseController<School,Byte>
    {
        private BaseService _service;
        //in ctor take parent service from DI and pass it to the base controller
        //when sending this entity type and its key type,
        //we tranform the Base service to this entity service (parent)
        public SchoolsController(BaseService service, Ado ado)
                                :base(service, "schools", "SchoolId", ado)
        {
            _service = service;
        }
    }
}
