using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class VerificationCode
    {
        public VerificationCode()
        {
            IsDeleted = false;
            SentTime = DateTime.UtcNow.AddHours(3);
        }

        public int CodeId { get; set; }
        public string Code { get; set; }
        public DateTime SentTime { get; set; }
        public byte? CodeTypeId { get; set; }
        public string UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public User User { get; set; }
        public VerificationCodeType VerificationCodeType { get; set; }
    }
}
