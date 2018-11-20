using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Shared
{
  public class CountriesController : BaseController<Country, Byte, Country>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;

    //in ctor take parent service from DI and pass it to the base controller
    //when sending this entity type and its key type,
    //we tranform the Base service to this entity service (parent)
    public CountriesController(BaseService service, IMapper mapper)
                                : base(service, mapper, "countries", "countryId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
