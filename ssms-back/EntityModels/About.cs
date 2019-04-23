using System;

namespace SSMS.EntityModels
{
    public class About
    {
        public int AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string AboutText { get; set; }
        public DateTime AboutDate { get; set; }
        public string PhotoURL { get; set; }
        public bool IsGlobal { get; set; }
        public byte? SchoolId { get; set; }
        public byte? StageId { get; set; }
        public int? EmpJobId { get; set; }
        public byte? CategoryId { get; set; }

        public School _School { get; set; }
        public Department _Department { get; set; }
        public EmployeeJob _EmployeeJob { get; set; }
        public MediaCategory _MediaCategory { get; set; }
    }
}
