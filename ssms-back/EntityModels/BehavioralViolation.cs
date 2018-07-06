using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class BehavioralViolation
    {
        public BehavioralViolation()
        {
            StudentsViolations = new HashSet<StudentViolation>();
        }

        public short ViolationId { get; set; }
        public string ViolationNameAr { get; set; }
        public string ViolationNameEn { get; set; }
        public byte? CategoryId { get; set; }

        public ICollection<StudentViolation> StudentsViolations { get; set; }
    }
}
