using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class StudentProcedure
    {
        public int StudentProcedureId { get; set; }
        public int? StudentViolationId { get; set; }
        public int? EmpJobId { get; set; }
        public short? ProcedureId { get; set; }
        public DateTime? ProcedureDate { get; set; }

        public EmployeeJob EmpJob { get; set; }
        public RemedialProcedure Procedure { get; set; }
        public StudentViolation StudentViolation { get; set; }
    }
}
