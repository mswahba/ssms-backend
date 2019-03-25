using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class District
    {
        public District()
        {
            ParentsAddresses = new HashSet<ParentAddress>();
        }

        public short DistrictId { get; set; }
        public string DistrictNameAr { get; set; }
        public string DistrictNameEn { get; set; }
        public short? CityId { get; set; }

        public ICollection<ParentAddress> ParentsAddresses { get; set; }
    }
}
