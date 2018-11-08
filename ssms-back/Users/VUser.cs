using System;
using System.Collections.Generic;

namespace SSMS.ViewModels
{
    public class VUser
    {
        public string UserId { get; set; }
        public byte? UserTypeId { get; set; }
        public byte? AccountStatusId { get; set; }
        public DateTime? SubscribeDate { get; set; }
        public DateTime? LastActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}