using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Job
    {
        public Job()
        {
            EmployeesJobs = new HashSet<EmployeeJob>();
            JobsActions = new HashSet<JobAction>();
        }

        public short JobId { get; set; }
        public string JobNameAr { get; set; }
        public string JobNameEn { get; set; }
        public string JobDescription { get; set; }

        public ICollection<EmployeeJob> EmployeesJobs { get; set; }
        public ICollection<JobAction> JobsActions { get; set; }
    }
}
