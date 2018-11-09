using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Students
{
    public class StudentsController : BaseController<Student, String>
    {
        private BaseService<Student, String> _StudentSrv { get; }
        public StudentsController(BaseService<Student, String> StudentsService, Ado ado)
                            : base(StudentsService, "students", "studentId", ado)
        {
            _StudentSrv = StudentsService;
        }
    }
}
