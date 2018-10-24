using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AcademicYear
    {
        public AcademicYear()
        {
            AcademicSemesters = new HashSet<AcademicSemester>();
            ClassesStudents = new HashSet<ClassStudent>();
            IsDeleted = false;
        }

        public byte YearId { get; set; }
        public string YearNameG { get; set; }
        public string YearNameH { get; set; }
        public DateTime? YearStartDateG { get; set; }
        public string YearStartDateH { get; set; }
        public DateTime? YearEndDateG { get; set; }
        public string YearEndDateH { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<AcademicSemester> AcademicSemesters { get; set; }
        public ICollection<ClassStudent> ClassesStudents { get; set; }
    }
}
