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

    public EmployeesController(BaseService service, IMapper mapper)
                                : base(service, mapper, "employees", "empId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}