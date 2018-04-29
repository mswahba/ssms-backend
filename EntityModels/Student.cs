using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Student
    {
        public Student()
        {
            ClassesStudents = new HashSet<ClassStudent>();
            PeriodsDetails = new HashSet<PeriodDetails>();
            StudentsViolations = new HashSet<StudentViolation>();
        }

        public string StudentId { get; set; }
        public string ParentId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string GName { get; set; }
        public string LName { get; set; }
        public bool? Gender { get; set; }
        public byte? IdType { get; set; }
        public string IdIssuePlace { get; set; }
        public DateTime? IdExpireDateG { get; set; }
        public string IdExpireDateH { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDateG { get; set; }
        public string BirthDateH { get; set; }
        public string BirthPlace { get; set; }
        public string SpecialNeeds { get; set; }
        public string PreviousSchool { get; set; }
        public bool? IsDeleted { get; set; }

        public Parent Parent { get; set; }
        public User _Student { get; set; }
        public ICollection<ClassStudent> ClassesStudents { get; set; }
        public ICollection<PeriodDetails> PeriodsDetails { get; set; }
        public ICollection<StudentViolation> StudentsViolations { get; set; }
    }
}
