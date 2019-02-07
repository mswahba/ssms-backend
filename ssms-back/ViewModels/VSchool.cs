using System;

namespace SSMS.ViewModels
{
    public class _VSchool
    {
        public byte SchoolId { get; set; }
        public string SchoolNameAr { get; set; }
        public string SchoolNameEn { get; set; }
        public DateTime? StartDate { get; set; }
        public string Address { get; set; }
        public string ComNum { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}