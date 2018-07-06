using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class EmployeeAction
    {
        public int EmpJobId { get; set; }
        public short ActionId { get; set; }

        public Action Action { get; set; }
        public EmployeeJob EmpJob { get; set; }
    }
}
