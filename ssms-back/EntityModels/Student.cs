using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Student : Person
    {
        public Student()
        {
            StudentsClasses = new HashSet<StudentClass>();
            PeriodsDetails = new HashSet<PeriodDetails>();
            StudentsViolations = new HashSet<StudentViolation>();
            IsDeleted = false;
        }

        public string StudentId { get; set; }
        public string ParentId { get; set; }
        public string FNameAr { get; set; }
        public string MNameAr { get; set; }
        public string GNameAr { get; set; }
        public string LNameAr { get; set; }
        public string FNameEn { get; set; }
        public string MNameEn { get; set; }
        public string GNameEn { get; set; }
        public string LNameEn { get; set; }
        public bool? Gender { get; set; }
        public byte? IdType { get; set; }
        public string IdIssuePlace { get; set; }
        public DateTime? IdExpireDateG { get; set; }
        public string IdExpireDateH { get; set; }
        public string Mobile { get; set; }
        public string MobileMother1 { get; set; }
        public string MobileMother2 { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDateG { get; set; }
        public string BirthDateH { get; set; }
        public string BirthPlace { get; set; }
        public string SpecialNeeds { get; set; }
        public string PreviousSchool { get; set; }
        public byte CountryId { get; set; }
        public string HealthIssuesIds { get; set; }
        public string HealthNeedsIds { get; set; }
        public int? AddressId { get; set; }
        public byte? StatusId { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public Parent Parent { get; set; }
        public User _Student { get; set; }
        public Country Country { get; set; }
        public ParentAddress ParentAddress { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public ICollection<StudentClass> StudentsClasses { get; set; }
        public ICollection<PeriodDetails> PeriodsDetails { get; set; }
        public ICollection<StudentViolation> StudentsViolations { get; set; }
    }
}
