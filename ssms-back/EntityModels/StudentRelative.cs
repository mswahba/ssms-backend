using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class StudentRelative
    {
        public int StudentRelativeId { get; set; }
        public string StudentId { get; set; }
        public int RelativeId { get; set; }
        public byte RelationId { get; set; }
        public byte? Priority { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
        public string IssuerId { get; set; }

        public Student _Student { get; set; }
        public Relative _Relative { get; set; }
        public Relation _Relation { get; set; }
        public User _User { get; set; }
    }
}
