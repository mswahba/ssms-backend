using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class User
    {
        public User()
        {
            UsersDocs = new HashSet<UsersDocs>();
        }

        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public byte? UserTypeId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? SubscribeDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsDeleted { get; set; }

        public UserType UserType { get; set; }
        public Employee _Employee { get; set; }
        public Parent _Parent { get; set; }
        public Student _Student { get; set; }
        public ICollection<UsersDocs> UsersDocs { get; set; }
    }
}
