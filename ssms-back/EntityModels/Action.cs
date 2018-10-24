using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Action
    {
        public Action()
        {
            EmployeesActions = new HashSet<EmployeeAction>();
            JobsActions = new HashSet<JobAction>();
            IsDeleted = false;
        }

        public short ActionId { get; set; }
        public string ActionNameAr { get; set; }
        public string ActionNameEn { get; set; }
        public string ActionUrl { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<EmployeeAction> EmployeesActions { get; set; }
        public ICollection<JobAction> JobsActions { get; set; }
    }
}
