using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
            IsDeleted = false;
        }

        public byte UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
