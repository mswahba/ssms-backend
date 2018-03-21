using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class User
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public byte? UserType { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? SubscribeDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
