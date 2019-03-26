using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class Relative
    {
        public Relative()
        {
            StudentsRelatives = new HashSet<StudentRelative>();
        }

        public int RelativeId { get; set; }
        public string RelativeNameAr { get; set; }
        public string RelativeNameEn { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ParentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public Parent _Parent { get; set; }
        public ICollection<StudentRelative> StudentsRelatives { get; set; }
    }
}
