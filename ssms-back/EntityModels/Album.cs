using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class Album
    {
        public Album()
        {
            this.Photos = new HashSet<Photo>();
        }

        public int AlbumId { get; set; }
        public string AlbumTitleAr { get; set; }
        public string AlbumTitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public DateTime AlbumDate { get; set; }
        public bool ForCompany { get; set; }
        public string DisplayAlsoAt { get; set; }
        public bool Approved { get; set; }
        public bool Enabled { get; set; }
        public string Keywords { get; set; }
        public byte? SchoolId { get; set; }
        public byte? StageId { get; set; }
        public int? EmpJobId { get; set; }
        public byte? CategoryId { get; set; }

        public School _School { get; set; }
        public Department _Department { get; set; }
        public EmployeeJob _EmployeeJob { get; set; }
        public MediaCategory _MediaCategory { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
