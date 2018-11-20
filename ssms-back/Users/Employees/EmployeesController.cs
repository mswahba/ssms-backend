using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Users.Employees
{
  public class EmployeesController : BaseController<Employee, String, Employee>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;

    public EmployeesController(BaseService service, IMapper mapper, Ado ado)
                                : base(service, mapper, "employees", "empId", ado)
    {
      _service = service;
      _mapper = mapper;
    }
  }
}