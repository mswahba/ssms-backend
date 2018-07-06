using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Department
    {
        public Department()
        {
            EmployeesJobs = new HashSet<EmployeeJob>();
        }

        public byte DepartmentId { get; set; }
        public string DepartmentNameAr { get; set; }
        public string DepartmentNameEn { get; set; }

        public ICollection<EmployeeJob> EmployeesJobs { get; set; }
    }
}
