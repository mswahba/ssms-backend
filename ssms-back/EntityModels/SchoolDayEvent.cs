using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class SchoolDayEvent
    {
        public SchoolDayEvent()
        {
            Periods = new HashSet<Period>();
            TimeTable = new HashSet<TimeTable>();
            IsDeleted = false;
        }

        public short SchoolDayEventId { get; set; }
        public byte? DayId { get; set; }
        public byte? StageId { get; set; }
        public string EventNameAr { get; set; }
        public string EventNameEn { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public Stage Stage { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<TimeTable> TimeTable { get; set; }
    }
}
