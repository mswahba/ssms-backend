﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class GradeSubject
    {
        public GradeSubject()
        {
            Periods = new HashSet<Period>();
            TeachersEdu = new HashSet<TeacherEdu>();
            TimeTable = new HashSet<TimeTable>();
            IsDeleted = false;
        }

        public short GradeSubjectId { get; set; }
        public byte GradeId { get; set; }
        public byte SubjectId { get; set; }
        public byte? PeriodsCount { get; set; }
        public bool? IsDeleted { get; set; }

        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<TeacherEdu> TeachersEdu { get; set; }
        public ICollection<TimeTable> TimeTable { get; set; }
    }
}
