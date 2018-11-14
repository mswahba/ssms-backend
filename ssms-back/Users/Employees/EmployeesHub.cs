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
    private BaseService _service;
    public EmployeesHub(BaseService service, Ado ado)
                            : base(service, "employees", "empId", ado)
    {
      _service = service;
    }
  }
}