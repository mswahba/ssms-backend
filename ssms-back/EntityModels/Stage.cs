using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Stage
    {
        public Stage()
        {
            Grades = new HashSet<Grade>();
            SchoolDayEvents = new HashSet<SchoolDayEvent>();
            IsDeleted = false;
        }
        public byte StageId { get; set; }
        public byte? BranchId { get; set; }
        public string StageNameAr { get; set; }
        public string StageNameEn { get; set; }
        public bool? IsDeleted { get; set; }

        public Branch Branch { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<SchoolDayEvent> SchoolDayEvents { get; set; }
    }
}
