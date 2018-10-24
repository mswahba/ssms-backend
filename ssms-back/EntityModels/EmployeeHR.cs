using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class EmployeeHr
    {
        public EmployeeHr()
        {
            IsDeleted = false;
        }
        public string EmpId { get; set; }
        public string JobInId { get; set; }
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
        public bool? IsDeleted { get; set; }

        public Employee Emp { get; set; }
    }
}
