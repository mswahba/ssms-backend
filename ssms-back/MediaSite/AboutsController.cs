
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using SSMS.Hubs;
using SSMS.EntityModels;

namespace SSMS.MediaSite
{
  public class AboutsController : BaseController<About, int, About>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;
    public AboutsController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                                : base(service, mapper, hubContext, "abouts", "aboutId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
