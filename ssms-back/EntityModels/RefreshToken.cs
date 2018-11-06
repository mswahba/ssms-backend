using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class RefreshToken
    {
        public RefreshToken()
        {
            IsDeleted = false;
        }
        public byte TokenId { get; set; }
        public string Token { get; set; }
        public string DeviceInfo { get; set; }
        public string UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public User User { get; set; }

    }
}
