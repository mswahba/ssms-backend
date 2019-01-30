using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Subject
    {
        public Subject()
        {
            GradesSubjects = new HashSet<GradeSubject>();
            IsDeleted = false;
        }

        public byte SubjectId { get; set; }
        public byte? MajorId { get; set; }
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public string ShortNameAr { get; set; }
        public string ShortNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public Major Major { get; set; }
        public ICollection<GradeSubject> GradesSubjects { get; set; }
    }
}
