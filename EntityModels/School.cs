﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class School
    {
        public byte SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolNameEn { get; set; }
        public DateTime? StartDate { get; set; }
        public string Address { get; set; }
        public string ComNum { get; set; }
        public bool? IsActive { get; set; }
    }
}
