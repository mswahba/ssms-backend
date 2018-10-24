using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class DocType
    {
        public DocType()
        {
            LessonsFiles = new HashSet<LessonFile>();
            PeriodsFiles = new HashSet<PeriodFile>();
            UsersDocs = new HashSet<UsersDocs>();
            IsDeleted = false;
        }

        public byte DocTypeId { get; set; }
        public string DocTypeAr { get; set; }
        public string DocTypeEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<LessonFile> LessonsFiles { get; set; }
        public ICollection<PeriodFile> PeriodsFiles { get; set; }
        public ICollection<UsersDocs> UsersDocs { get; set; }
    }
}
