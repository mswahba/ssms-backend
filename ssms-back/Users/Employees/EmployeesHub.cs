using System;
using System.Linq;
using SSMS.EntityModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SSMS.Hubs
{
  public class EmployeesHub : BaseHub<Employee, String>
  {
    private BaseService<Employee, String> _EmployeeSrv;
    public EmployeesHub(BaseService<Employee, String> employeesService, Ado ado)
                            : base(employeesService, "employees", "empId", ado)
    {
      _EmployeeSrv = employeesService;
    }
  }
}