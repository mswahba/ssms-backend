using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SSMS.EntityModels;
using SSMS.Hubs;

namespace SSMS.Students
{
  public class StudentsController : BaseController<Student, String, Student>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;

    public StudentsController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                            : base(service, mapper, hubContext, "students", "studentId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
