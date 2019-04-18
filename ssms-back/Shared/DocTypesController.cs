using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using SSMS.EntityModels;
using SSMS.Hubs;

namespace SSMS.Shared
{
  public class DocTypesController : BaseController<DocType, Byte, DocType>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;

    //in ctor take parent service from DI and pass it to the base controller
    //when sending this entity type and its key type,
    //we tranform the Base service to this entity service (parent)
    public DocTypesController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                                : base(service, mapper, hubContext, "docTypes", "docTypeId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
