using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Grade
    {
        public Grade()
        {
            Classrooms = new HashSet<Classrooms>();
            GradesSubjects = new HashSet<GradesSubjects>();
            IsDeleted = false;
        }

        public byte GradeId { get; set; }
        public byte? StageId { get; set; }
        public string GradeNameAr { get; set; }
        public string GradeNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public Stage Stage { get; set; }
        public ICollection<Classrooms> Classrooms { get; set; }
        public ICollection<GradesSubjects> GradesSubjects { get; set; }
    }
}
