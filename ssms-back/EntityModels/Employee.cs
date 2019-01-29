using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Employee : Person
    {
        public Employee()
        {
            EmployeesJobs = new HashSet<EmployeeJob>();
            IsDeleted = false;
        }

        public string EmpId { get; set; }
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
        public byte? CountryId { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDateG { get; set; }
        public string BirthDateH { get; set; }
        public string BirthPlace { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string PassportNum { get; set; }
        public DateTime? PassportExpireDateG { get; set; }
        public string PassportExpireDateH { get; set; }
        public string AddressKsa { get; set; }
        public string AddressHome { get; set; }
        public byte? CertificateDegree { get; set; }
        public string CertificateName { get; set; }
        public string CertificateDate { get; set; }
        public byte? CertificateGrade { get; set; }
        public string CertificateMajor { get; set; }
        public string RelativeName { get; set; }
        public string RelativeAddress { get; set; }
        public string RelativeMobile { get; set; }
        public string RelativePhone { get; set; }
        public string PoBox { get; set; }
        public string PoCode { get; set; }
        public bool? HasDrivingLicense { get; set; }
        public bool? IsHandicapped { get; set; }
        public string SpecialNeeds { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public User Emp { get; set; }
        public EmployeeFinance EmployeesFinance { get; set; }
        public EmployeeHr EmployeesHr { get; set; }
        public Country Country { get; set; }
        public ICollection<EmployeeJob> EmployeesJobs { get; set; }
    }
}
