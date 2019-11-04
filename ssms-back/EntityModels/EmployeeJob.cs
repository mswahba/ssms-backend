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
            Abouts = new HashSet<About>();
            Articles = new HashSet<Article>();
            Albums = new HashSet<Album>();
            Photos = new HashSet<Photo>();
            ContactUsMessages = new HashSet<ContactUsMessage>();
            IsDeleted = false;
        }

        public int EmpJobId { get; set; }
        public string EmpId { get; set; }
        public short JobId { get; set; }
        public byte? BranchId { get; set; }
        public byte? DepartmentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
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
        public ICollection<About> Abouts { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<ContactUsMessage> ContactUsMessages { get; set; }
    }
}
