using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class ViolationDegree
    {
        public ViolationDegree()
        {
            Procedures = new HashSet<Procedure>();
            Violations = new HashSet<Violation>();
        }

        public byte DegreeId { get; set; }
        public string DegreeNameAr { get; set; }
        public string DegreeNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
        public ICollection<Violation> Violations { get; set; }
    }
}
