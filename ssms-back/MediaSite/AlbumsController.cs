
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using SSMS.Hubs;
using SSMS.EntityModels;

namespace SSMS.MediaSite
{
  public class AlbumsController : BaseController<Album, int, Album>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;
    public AlbumsController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                                : base(service, mapper, hubContext, "albums", "albumId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
