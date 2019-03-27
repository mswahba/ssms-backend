using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class City
    {
        public City()
        {
            ParentsAddresses = new HashSet<ParentAddress>();
            Districts = new HashSet<District>();
        }

        public short CityId { get; set; }
        public string CityNameAr { get; set; }
        public string CityNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<District> Districts { get; set; }
        public ICollection<ParentAddress> ParentsAddresses { get; set; }
    }
}
