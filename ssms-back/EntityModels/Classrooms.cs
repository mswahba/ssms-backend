using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Classrooms
    {
        public Classrooms()
        {
            ClassesStudents = new HashSet<ClassStudent>();
            Periods = new HashSet<Period>();
            IsDeleted = false;
        }

        public short ClassroomId { get; set; }
        public byte? GradeId { get; set; }
        public string ClassNameAr { get; set; }
        public string ClassNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public Grade Grade { get; set; }
        public ICollection<ClassStudent> ClassesStudents { get; set; }
        public ICollection<Period> Periods { get; set; }
    }
}
