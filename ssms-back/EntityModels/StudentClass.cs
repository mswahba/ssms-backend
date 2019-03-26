using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentClass
    {
        public StudentClass()
        {
            StudentsViolations = new HashSet<StudentViolation>();
            IsDeleted = false;
        }
        public int StudentClassId { get; set; }
        public string StudentId { get; set; }
        public byte? YearId { get; set; }
        public short? ClassroomId { get; set; }
        public bool? IsDeleted { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }

        public Classroom _Classroom { get; set; }
        public Student _Student { get; set; }
        public AcademicYear Year { get; set; }
        public User _User { get; set; }

        public ICollection<StudentViolation> StudentsViolations { get; set; }
    }
}
