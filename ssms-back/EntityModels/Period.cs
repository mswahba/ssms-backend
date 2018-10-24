using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Period
    {
        public Period()
        {
            PeriodsDetails = new HashSet<PeriodDetails>();
            IsDeleted = false;
        }

        public int PeriodId { get; set; }
        public byte? SemesterId { get; set; }
        public short? ClasseroomId { get; set; }
        public short? GradeSubjectId { get; set; }
        public int? EmpJobId { get; set; }
        public short? SchoolDayEventId { get; set; }
        public DateTime? PeriodDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public Classrooms Classeroom { get; set; }
        public EmployeeJob EmpJob { get; set; }
        public GradesSubjects GradeSubject { get; set; }
        public SchoolDayEvent SchoolDayEvent { get; set; }
        public AcademicSemester Semester { get; set; }
        public ICollection<PeriodDetails> PeriodsDetails { get; set; }
    }
}
