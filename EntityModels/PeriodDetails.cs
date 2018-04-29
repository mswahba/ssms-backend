using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class PeriodDetails
    {
        public long PeriodDetailId { get; set; }
        public int? PeriodId { get; set; }
        public string StudentId { get; set; }
        public TimeSpan? AttandanceTime { get; set; }
        public TimeSpan? LeaveTime { get; set; }
        public bool? IsEalryExit { get; set; }
        public byte? HomeworkRate { get; set; }
        public byte? ParticipationsCount { get; set; }
        public byte? ParticipationsQuality { get; set; }
        public string Notes { get; set; }

        public Period Period { get; set; }
        public Student Student { get; set; }
    }
}
