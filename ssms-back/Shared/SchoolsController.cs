using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using SSMS.ViewModels;

namespace SSMS.Shared
{
  public class SchoolsController : BaseController<School, Byte, VSchool>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;

    //in ctor take parent service from DI and pass it to the base controller
    //when sending this entity type and its key type,
    //we tranform the Base service to this entity service (parent)
    public SchoolsController(BaseService service, IMapper mapper)
                                : base(service, mapper, "schools", "SchoolId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
