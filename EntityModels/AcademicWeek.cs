using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AcademicWeek
    {
        public short WeekId { get; set; }
        public byte? SemesterId { get; set; }
        public byte? YearId { get; set; }
        public string WeekNameAr { get; set; }
        public string WeekNameEn { get; set; }
        public DateTime? WeekStartDateG { get; set; }
        public string WeekStartDateH { get; set; }
        public DateTime? WeekEndDateG { get; set; }
        public string WeekEndDateH { get; set; }
    }
}
