using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AcademicSemester
    {
        public byte SemesterId { get; set; }
        public byte? YearId { get; set; }
        public string SemesterNameAr { get; set; }
        public string SemesterNameEn { get; set; }
        public DateTime? SemesterStartDateG { get; set; }
        public string SemesterStartDateH { get; set; }
        public DateTime? SemesterEndDateG { get; set; }
        public string SemesterEndDateH { get; set; }
    }
}
