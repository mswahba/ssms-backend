using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Subject
    {
        public Subject()
        {
            GradesSubjects = new HashSet<GradesSubjects>();
        }

        public byte SubjectId { get; set; }
        public byte? MajorId { get; set; }
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public string ShortNameAr { get; set; }
        public string ShortNameEn { get; set; }

        public Major Major { get; set; }
        public ICollection<GradesSubjects> GradesSubjects { get; set; }
    }
}
