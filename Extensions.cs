using System;
using SSMS.EntityModels;
using SSMS.Users;

namespace SSMS
{
    public static class Extensions
    {
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