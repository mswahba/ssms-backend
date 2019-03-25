using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Classroom
    {
        public Classroom()
        {
            StudentsClasses = new HashSet<StudentClass>();
            Periods = new HashSet<Period>();
            IsDeleted = false;
        }

        public short ClassroomId { get; set; }
        public byte? GradeId { get; set; }
        public string ClassNameAr { get; set; }
        public string ClassNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public Grade Grade { get; set; }
        public ICollection<StudentClass> StudentsClasses { get; set; }
        public ICollection<Period> Periods { get; set; }
    }
}
