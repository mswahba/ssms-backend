using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class TeacherQuorum
    {
        public TeacherQuorum()
        {
            IsDeleted = false;
        }
        public int TeacherQuorumId { get; set; }
        public int? EmpJobId { get; set; }
        public byte? SemesterId { get; set; }
        public byte? PeriodsQuorum { get; set; }
        public byte? SubstituteQuorum { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public EmployeeJob EmpJob { get; set; }
        public AcademicSemester Semester { get; set; }
    }
}
