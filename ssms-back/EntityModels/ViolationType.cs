using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class ViolationType
    {
        public ViolationType()
        {
            Violations = new HashSet<Violation>();
        }

        public byte TypeId { get; set; }
        public string TypeNameAr { get; set; }
        public string TypeNameEn { get; set; }

        public ICollection<Violation> Violations { get; set; }
    }
}
