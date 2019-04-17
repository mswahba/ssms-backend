using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class School
    {
        public School()
        {
            Branches = new HashSet<Branch>();
            Abouts = new HashSet<About>();
            Articles = new HashSet<Article>();
            Albums = new HashSet<Album>();
            IsDeleted = false;
        }

        public byte SchoolId { get; set; }
        public string SchoolNameAr { get; set; }
        public string SchoolNameEn { get; set; }
        public DateTime? StartDate { get; set; }
        public string Address { get; set; }
        public string ComNum { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
