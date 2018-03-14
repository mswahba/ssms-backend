using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Classroom
    {
        public byte ClassroomId { get; set; }
        public byte? GradeId { get; set; }
        public byte? StageId { get; set; }
        public byte? SectionId { get; set; }
        public string ClassNameAr { get; set; }
        public string ClassNameEn { get; set; }
    }
}
