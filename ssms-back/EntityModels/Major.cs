﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Major
    {
        public Major()
        {
            Subjects = new HashSet<Subject>();
            IsDeleted = false;
        }

        public byte MajorId { get; set; }
        public string MajorNameAr { get; set; }
        public string MajorNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
