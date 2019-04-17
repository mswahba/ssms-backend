using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class MediaCategory
    {
        public MediaCategory()
        {
            Albums = new HashSet<Album>();
            Abouts = new HashSet<About>();
        }

        public byte CategoryId { get; set; }
        public string CategoryNameAr { get; set; }
        public string CategoryNameEn { get; set; }
        public string CategoryType { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<About> Abouts { get; set; }
    }
}
