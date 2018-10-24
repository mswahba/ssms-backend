using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class LessonFile
    {
        public LessonFile()
        {
            IsDeleted = false;
        }
        public int LessonFileId { get; set; }
        public int? LessonId { get; set; }
        public byte? DocTypeId { get; set; }
        public string FilePath { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsExternalLink { get; set; }
        public bool? IsDeleted { get; set; }

        public DocType DocType { get; set; }
        public Lesson Lesson { get; set; }
    }
}
