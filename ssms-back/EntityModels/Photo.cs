using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoTitleAr { get; set; }
        public string PhotoTitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string PhotoURL { get; set; }
        public string ThumbURL { get; set; }
        public string MoreURL { get; set; }
        public DateTime PhotoDate { get; set; }
        public bool Approved { get; set; }
        public bool Enabled { get; set; }
        public int? EmpJobId { get; set; }
        public int? AlbumId { get; set; }

        public EmployeeJob _EmployeeJob { get; set; }
        public Album _Album { get; set; }
    }
}
