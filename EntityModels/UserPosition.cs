using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class UserPosition
    {
        public string UserId { get; set; }
        public short PositionId { get; set; }
        public byte? SectionId { get; set; }
        public byte? DepartmentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
