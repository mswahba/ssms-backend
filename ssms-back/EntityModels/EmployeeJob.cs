using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class EmployeeJob
    {
        public EmployeeJob()
        {
            EmployeesActions = new HashSet<EmployeeAction>();
            Periods = new HashSet<Period>();
            StudentsProcedures = new HashSet<StudentProcedure>();
            StudentsViolations = new HashSet<StudentViolation>();
            TeachersEdu = new HashSet<TeacherEdu>();
            TeachersQuorums = new HashSet<TeacherQuorum>();
            TimeTable = new HashSet<TimeTable>();
        }

        public int EmpJobId { get; set; }
        public string EmpId { get; set; }
        public short JobId { get; set; }
        public byte? BranchId { get; set; }
        public byte? DepartmentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Department Department { get; set; }
        public Employee Emp { get; set; }
        public Job Job { get; set; }
        public ICollection<EmployeeAction> EmployeesActions { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<StudentProcedure> StudentsProcedures { get; set; }
        public ICollection<StudentViolation> StudentsViolations { get; set; }
        public ICollection<TeacherEdu> TeachersEdu { get; set; }
        public ICollection<TeacherQuorum> TeachersQuorums { get; set; }
        public ICollection<TimeTable> TimeTable { get; set; }
    }
}
