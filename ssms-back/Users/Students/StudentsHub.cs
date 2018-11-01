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
    private BaseService<Student, String> _StudentSrv;
    public StudentsHub(BaseService<Student, String> studentsService, Ado ado)
                        : base(studentsService, "students", "studentId", ado)
    {
      _StudentSrv = studentsService;
    }
  }
}
