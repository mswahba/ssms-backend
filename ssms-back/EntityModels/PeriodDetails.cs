using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class PeriodDetails
    {
        public PeriodDetails()
        {
            IsDeleted = false;
        }
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
        public string IssuerId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public User _User { get; set; }
        public Period Period { get; set; }
        public Student Student { get; set; }
    }
}
