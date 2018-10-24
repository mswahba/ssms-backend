using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AcademicSemester
    {
        public AcademicSemester()
        {
            AcademicWeeks = new HashSet<AcademicWeek>();
            Periods = new HashSet<Period>();
            TeachersQuorums = new HashSet<TeacherQuorum>();
            IsDeleted = false;
        }

        public byte SemesterId { get; set; }
        public byte? YearId { get; set; }
        public string SemesterNameAr { get; set; }
        public string SemesterNameEn { get; set; }
        public DateTime? SemesterStartDateG { get; set; }
        public string SemesterStartDateH { get; set; }
        public DateTime? SemesterEndDateG { get; set; }
        public string SemesterEndDateH { get; set; }
        public bool? IsDeleted { get; set; }
        public AcademicYear Year { get; set; }
        public ICollection<AcademicWeek> AcademicWeeks { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<TeacherQuorum> TeachersQuorums { get; set; }
    }
}
