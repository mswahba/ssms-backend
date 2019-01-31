using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class EmployeeAction
    {
        public EmployeeAction()
        {
            IsDeleted = false;
        }
        public int EmpJobId { get; set; }
        public short ActionId { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public Action Action { get; set; }
        public EmployeeJob EmpJob { get; set; }
    }
}
