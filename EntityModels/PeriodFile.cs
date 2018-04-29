using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class PeriodFile
    {
        public int PeriodFileId { get; set; }
        public byte? DocTypeId { get; set; }
        public short? WeekPlanId { get; set; }
        public string FilePath { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsExternalLink { get; set; }

        public DocType DocType { get; set; }
        public WeekPlan WeekPlan { get; set; }
    }
}
