using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class GradeSubject
    {
        public byte GradeId { get; set; }
        public byte SubjectId { get; set; }
        public byte? PeriodNumber { get; set; }
    }
}
