
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using SSMS.Hubs;
using SSMS.EntityModels;

namespace SSMS.MediaSite
{
  public class ArticlesController : BaseController<Article, int, About>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;
    public ArticlesController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                                : base(service, mapper, hubContext, "articles", "articleId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
