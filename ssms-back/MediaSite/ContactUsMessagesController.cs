
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using SSMS.Hubs;
using SSMS.EntityModels;

namespace SSMS.MediaSite
{
  public class ContactUsMessagesController : BaseController<ContactUsMessage, int, ContactUsMessage>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IHubContext<DbHub> _hubContext;
    public ContactUsMessagesController(BaseService service, IMapper mapper, IHubContext<DbHub> hubContext)
                                : base(service, mapper, hubContext, "contactUsMessages", "messageId")
    {
      _service = service;
      _mapper = mapper;
      _hubContext = hubContext;
    }
  }
}
