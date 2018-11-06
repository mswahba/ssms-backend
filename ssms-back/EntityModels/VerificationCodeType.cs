using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class VerificationCodeType
    {
        public VerificationCodeType()
        {
            VerificationCodes = new HashSet<VerificationCode>();
            IsDeleted = false;
        }

        public byte CodeTypeId { get; set; }
        public string CodeType { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<VerificationCode> VerificationCodes { get; set; }
    }
}
