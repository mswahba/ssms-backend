using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Subject
    {
        public byte SubjectId { get; set; }
        public byte? MajorId { get; set; }
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
    }
}
