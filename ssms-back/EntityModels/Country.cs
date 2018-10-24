using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Country
    {
        public Country()
        {
            Parents = new HashSet<Parent>();
            Students = new HashSet<Student>();
            Employees = new HashSet<Employee>();
            IsDeleted = false;
        }
        public byte CountryId { get; set; }
        public string CountryAr { get; set; }
        public string CountryEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Parent> Parents { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}