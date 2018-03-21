using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Employee
    {
        public string EmptId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string GName { get; set; }
        public string LName { get; set; }
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
        public DateTime? PasspoerExpireDateG { get; set; }
        public string PasspoerExpireDateH { get; set; }
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
        public bool? IsDeleted { get; set; }
    }
}
