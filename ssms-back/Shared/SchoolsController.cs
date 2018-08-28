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
        private BaseService<School,Byte> _SchoolSrv { get; }
        //in ctor take parent service from DI and pass it to the base controller
        //when sending this entity type and its key type,
        //we tranform the Base service to this entity service (parent)
        public SchoolsController(BaseService<School,Byte> SchoolsService)
                                :base(SchoolsService, "schools", "SchoolId", null)
        {
            _SchoolSrv = SchoolsService;
        }
    }
}
