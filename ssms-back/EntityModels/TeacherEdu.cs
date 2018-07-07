﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class TeacherEdu
    {
        public int EmpJobId { get; set; }
        public short GradeSubjectId { get; set; }
        public string ClassroomIds { get; set; }

        public EmployeeJob EmpJob { get; set; }
        public GradesSubjects GradeSubject { get; set; }
    }
}