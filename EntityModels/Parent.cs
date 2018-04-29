using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Parent
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }

        public string ParentId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string GName { get; set; }
        public string LName { get; set; }
        public byte? IdType { get; set; }
        public string IdIssuePlace { get; set; }
        public DateTime? IdExpireDateG { get; set; }
        public string IdExpireDateH { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string MobileMother { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string HouseNum { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public byte? CityId { get; set; }
        public string Job { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public string RelativeName { get; set; }
        public string RelativeMobile { get; set; }
        public string RelativePhone { get; set; }
        public string RelativeAddress { get; set; }
        public string RelativeRelation { get; set; }
        public bool? IsDeleted { get; set; }

        public User _Parent { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
