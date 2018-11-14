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
        private BaseService _service;
        public EmployeesController(BaseService service, Ado ado)
                                :base(service, "employees", "empId", ado)
        {
            _service = service;
        }
    }
}