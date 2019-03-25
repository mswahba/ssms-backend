using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class City
    {
        public City()
        {
            ParentsAddresses = new HashSet<ParentAddress>();
        }

        public short cityId { get; set; }
        public string cityNameAr { get; set; }
        public string cityNameEn { get; set; }

        public ICollection<ParentAddress> ParentsAddresses { get; set; }
    }
}
