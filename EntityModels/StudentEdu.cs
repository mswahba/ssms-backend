using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentEdu
    {
        public string StudentId { get; set; }
        public string PreviousSchool { get; set; }
        public byte? SectionId { get; set; }
        public byte? StageId { get; set; }
        public byte? GradeId { get; set; }
        public byte? ClassId { get; set; }
    }
}
