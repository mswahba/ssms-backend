﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Parent : Person
    {
        public Parent()
        {
            Students = new HashSet<Student>();
            IsDeleted = false;
        }

        public string ParentId { get; set; }
        public string FNameAr { get; set; }
        public string MNameAr { get; set; }
        public string GNameAr { get; set; }
        public string LNameAr { get; set; }
        public string FNameEn { get; set; }
        public string MNameEn { get; set; }
        public string GNameEn { get; set; }
        public string LNameEn { get; set; }
        public byte? IdType { get; set; }
        public string IdIssuePlace { get; set; }
        public DateTime? IdExpireDateG { get; set; }
        public string IdExpireDateH { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public byte? CountryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string HouseNum { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public byte? CityId { get; set; }
        public string Job { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public string RelativeName { get; set; }
        public string RelativeMobile { get; set; }
        public string RelativePhone { get; set; }
        public string RelativeAddress { get; set; }
        public string RelativeRelation { get; set; }
        public bool? IsDeleted { get; set; }

        public User _Parent { get; set; }
        public Country Country { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
