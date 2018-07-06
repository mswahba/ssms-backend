using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public byte UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
