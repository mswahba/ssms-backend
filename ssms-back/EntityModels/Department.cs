using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Department
    {
        public Department()
        {
            EmployeesJobs = new HashSet<EmployeeJob>();
            Abouts = new HashSet<About>();
            Articles = new HashSet<Article>();
            Albums = new HashSet<Album>();
            IsDeleted = false;
        }

        public byte DepartmentId { get; set; }
        public string DepartmentNameAr { get; set; }
        public string DepartmentNameEn { get; set; }
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public ICollection<EmployeeJob> EmployeesJobs { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
