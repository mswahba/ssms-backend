using System;
using AutoMapper;
using SSMS.EntityModels;
using SSMS.ViewModels;

namespace SSMS
{
  public class Mappings : Profile
  {
    public Mappings()
    {
      CreateMap<User, _VUser>().ReverseMap();
      CreateMap<School, _VSchool>().ReverseMap();
    }
  }
}