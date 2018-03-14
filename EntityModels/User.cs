using System;
using System.Collections.Generic;
using SSMS.Users;

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
        public static User Map(SignUp signup)
        {
            return new User()
            {
                UserId= signup.UserId,
                UserPassword= signup.UserPassword,
                UserType= signup.UserType, 
                SubscribeDate = DateTime.UtcNow.AddHours(3),
                IsActive= false
            };
        }
    }
}
