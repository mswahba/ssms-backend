using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Grade
    {
        public byte GradeId { get; set; }
        public byte? StageId { get; set; }
        public string GradeNameAr { get; set; }
        public string GradeNameEn { get; set; }
    }
}
