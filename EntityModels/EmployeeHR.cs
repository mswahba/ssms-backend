using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class EmployeeHR
    {
        public string EmpId { get; set; }
        public string JobInId { get; set; }
        public string JobInSchool { get; set; }
        public byte? SchoolGender { get; set; }
        public byte? DepartmentId { get; set; }
        public string ContractType { get; set; }
        public bool? SocialSecuritySubscription { get; set; }
        public int? SocialSecurityNum { get; set; }
        public DateTime? CeoApproval { get; set; }
        public int? SalahiaNum { get; set; }
        public DateTime? SalahiaDateG { get; set; }
        public string SalahiaDateH { get; set; }
        public DateTime? WrokStartDateG { get; set; }
        public string WorkStartDateH { get; set; }
        public bool? NoorRegistered { get; set; }
        public byte? WorkStatus { get; set; }
        public string HrNotes { get; set; }
    }
}
