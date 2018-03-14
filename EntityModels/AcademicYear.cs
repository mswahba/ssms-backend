using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AcademicYear
    {
        public byte YearId { get; set; }
        public string YearNameG { get; set; }
        public string YearNameH { get; set; }
        public DateTime? YearStartDateG { get; set; }
        public string YearStartDateH { get; set; }
        public DateTime? YearEndDateG { get; set; }
        public string YearEndDateH { get; set; }
    }
}
