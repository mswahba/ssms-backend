using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentViolation
    {
        public StudentViolation()
        {
            StudentsProcedures = new HashSet<StudentProcedure>();
            IsDeleted = false;
        }

        public int StudentViolationId { get; set; }
        public string StudentId { get; set; }
        public short? ViolationId { get; set; }
        public int? EmpJobId { get; set; }
        public DateTime? ViolationDate { get; set; }
        public bool? IsDeleted { get; set; }

        public EmployeeJob EmpJob { get; set; }
        public Student Student { get; set; }
        public BehavioralViolation Violation { get; set; }
        public ICollection<StudentProcedure> StudentsProcedures { get; set; }
    }
}
