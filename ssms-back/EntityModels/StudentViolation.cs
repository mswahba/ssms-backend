using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentViolation
    {
        public StudentViolation()
        {
            StudentsProcedures = new HashSet<StudentProcedure>();
        }

        public int StudentViolationId { get; set; }
        public short? ViolationId { get; set; }
        public string StudentId { get; set; }
        public int? StudentClassId { get; set; }
        public int? EmpJobId { get; set; }
        public DateTime? ViolationDate { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }

		public User _User { get; set; }
        public Violation _Violation { get; set; }
        public Student _Student { get; set; }
        public StudentClass _StudentClass { get; set; }
        public EmployeeJob EmpJob { get; set; }
        public ICollection<StudentProcedure> StudentsProcedures { get; set; }
    }
}
