using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Hubs
{
  public class StudentsHub : BaseHub<Student, String>
  {
    private BaseService _service;
    public StudentsHub(BaseService service, Ado ado)
                        : base(service, "students", "studentId", ado)
    {
      _service = service;
    }
  }
}
