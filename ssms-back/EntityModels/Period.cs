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
        public short? ClassroomId { get; set; }
        public short? GradeSubjectId { get; set; }
        public int? EmpJobId { get; set; }
        public short? SchoolDayEventId { get; set; }
        public DateTime? PeriodDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public Classroom _Classroom { get; set; }
        public EmployeeJob EmpJob { get; set; }
        public GradeSubject GradeSubject { get; set; }
        public SchoolDayEvent SchoolDayEvent { get; set; }
        public AcademicSemester Semester { get; set; }
        public ICollection<PeriodDetails> PeriodsDetails { get; set; }
    }
}
