using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Branch
    {
        public Branch()
        {
            Departments = new HashSet<Department>();
            IsDeleted = false;
        }

        public byte BranchId { get; set; }
        public string BranchNameAr { get; set; }
        public string BranchNameEn { get; set; }
        public byte? SchoolId { get; set; }
        public bool? IsDeleted { get; set; }

        public School School { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
