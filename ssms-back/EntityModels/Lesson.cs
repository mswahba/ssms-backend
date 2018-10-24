using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Lesson
    {
        public Lesson()
        {
            LessonsFiles = new HashSet<LessonFile>();
            WeeksPlans = new HashSet<WeekPlan>();
            IsDeleted = false;
        }

        public int LessonId { get; set; }
        public short? GradeSubjectId { get; set; }
        public byte? SemesterId { get; set; }
        public string LessonTitle { get; set; }
        public string LessonObjectives { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<LessonFile> LessonsFiles { get; set; }
        public ICollection<WeekPlan> WeeksPlans { get; set; }
    }
}
