using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentProcedure
    {
        public StudentProcedure() {}
        public int StudentProcedureId { get; set; }
        public int? StudentViolationId { get; set; }
        public short? ProcedureId { get; set; }
        public int? EmpJobId { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
		public User _User { get; set; }
        public StudentViolation _StudentViolation { get; set; }
        public Procedure _Procedure { get; set; }
        public EmployeeJob EmpJob { get; set; }
    }
}
