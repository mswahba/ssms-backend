using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class TimeTable
    {
        public TimeTable()
        {
            WeeksPlans = new HashSet<WeekPlan>();
            IsDeleted = false;
        }

        public int TimeTableId { get; set; }
        public short ClassroomId { get; set; }
        public short SchoolDayEventId { get; set; }
        public short? GradeSubjectId { get; set; }
        public int? EmpJobId { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }        
        public EmployeeJob EmpJob { get; set; }
        public GradeSubject GradeSubject { get; set; }
        public SchoolDayEvent SchoolDayEvent { get; set; }
        public ICollection<WeekPlan> WeeksPlans { get; set; }
    }
}
