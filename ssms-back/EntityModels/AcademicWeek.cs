using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AcademicWeek
    {
        public AcademicWeek()
        {
            WeeksPlans = new HashSet<WeekPlan>();
        }

        public short WeekId { get; set; }
        public byte? SemesterId { get; set; }
        public string WeekNameAr { get; set; }
        public string WeekNameEn { get; set; }
        public DateTime? WeekStartDateG { get; set; }
        public string WeekStartDateH { get; set; }
        public DateTime? WeekEndDateG { get; set; }
        public string WeekEndDateH { get; set; }

        public AcademicSemester Semester { get; set; }
        public ICollection<WeekPlan> WeeksPlans { get; set; }
    }
}
