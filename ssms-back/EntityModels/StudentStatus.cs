using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class StudentStatus
    {
        public StudentStatus()
        {
           Students = new HashSet<Student>();
        }
        public byte StatusId { get; set; }
        public string StatusNameAr { get; set; }
        public string StatusNameEn { get; set; }
        public string Notes { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
