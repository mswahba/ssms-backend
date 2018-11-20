using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Students
{
  public class StudentsController : BaseController<Student, String, Student>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;

    public StudentsController(BaseService service, IMapper mapper)
                            : base(service, mapper, "students", "studentId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
