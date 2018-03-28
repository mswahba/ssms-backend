using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Users.Employees  
{
    public class EmployeesController : BaseController<Employee,String>
    {
        private BaseService<Employee,String> _EmployeeSrv { get; }
        public EmployeesController(BaseService<Employee,String> EmployeesService):base(EmployeesService)
        {
            _EmployeeSrv = EmployeesService;    
        }
    }
}