using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class AccountStatus
    {
        public AccountStatus()
        {
            Users = new List<User>();
            IsDeleted = false;
        }

        public byte StatusId { get; set; }
        public string StatusAr { get; set; }
        public string StatusEn { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
