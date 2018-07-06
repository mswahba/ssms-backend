using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class TimeTable
    {
        public TimeTable()
        {
            WeeksPlans = new HashSet<WeekPlan>();
        }

        public int TimeTableId { get; set; }
        public short ClassroomId { get; set; }
        public short SchoolDayEventId { get; set; }
        public short? GradeSubjectId { get; set; }
        public int? EmpJobId { get; set; }

        public EmployeeJob EmpJob { get; set; }
        public GradesSubjects GradeSubject { get; set; }
        public SchoolDayEvent SchoolDayEvent { get; set; }
        public ICollection<WeekPlan> WeeksPlans { get; set; }
    }
}
