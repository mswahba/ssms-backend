using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class ParentAddress
    {
        public ParentAddress()
        {
           Students = new HashSet<Student>();
        }
        public int AddressId { get; set; }
        public string ParentId { get; set; }
        public short? CityId { get; set; }
        public short? DistrictId { get; set; }
        public string StreetName { get; set; }
        public short? HouseNumber { get; set; }
        public string ExtraDetails { get; set; }
        public string Coords { get; set; }
        public string Phone { get; set; }
        public bool? IsMain { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public string IssuerId { get; set; }

        public Parent _Parent { get; set; }
        public City _City { get; set; }
        public District _District { get; set; }
        public User _User { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
