using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Branch
    {
        public Branch()
        {
            Stages = new HashSet<Stage>();
        }

        public byte BranchId { get; set; }
        public string BranchNameAr { get; set; }
        public string BranchNameEn { get; set; }
        public byte? SchoolId { get; set; }

        public School School { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
