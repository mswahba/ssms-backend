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
using SSMS.ViewModels;

namespace SSMS.Shared
{
  public class SchoolsController : BaseController<School, Byte, _VSchool>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;

    //in ctor take parent service from DI and pass it to the base controller
    //when sending this entity type and its key type,
    //we tranform the Base service to this entity service (parent)
    public SchoolsController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                                : base(service, mapper, hubContext, "schools", "SchoolId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
