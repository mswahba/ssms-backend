using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Grade
    {
        public Grade()
        {
            Classrooms = new HashSet<Classroom>();
            GradesSubjects = new HashSet<GradeSubject>();
            IsDeleted = false;
        }

        public byte GradeId { get; set; }
        public byte? StageId { get; set; }
        public string GradeNameAr { get; set; }
        public string GradeNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public Stage Stage { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
        public ICollection<GradeSubject> GradesSubjects { get; set; }
    }
}
