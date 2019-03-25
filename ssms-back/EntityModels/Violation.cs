using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Violation
    {
        public Violation()
        {
            StudentsViolations = new HashSet<StudentViolation>();
            IsDeleted = false;
        }

        public short ViolationId { get; set; }
        public string ViolationNameAr { get; set; }
        public string ViolationNameEn { get; set; }
        public byte DegreeId { get; set; }
        public byte TypeId { get; set; }
        public bool? IsDeleted { get; set; }

        public ViolationDegree _ViolationDegree { get; set; }
        public ViolationType _ViolationType { get; set; }

        public ICollection<StudentViolation> StudentsViolations { get; set; }
    }
}
