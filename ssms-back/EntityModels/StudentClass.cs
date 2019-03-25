using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentClass
    {
        public StudentClass()
        {
            IsDeleted = false;
        }
        public int ClassStudentId { get; set; }
        public string StudentId { get; set; }
        public byte? YearId { get; set; }
        public short? ClassroomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }

        public Classroom Classroom { get; set; }
        public Student Student { get; set; }
        public AcademicYear Year { get; set; }
    }
}
