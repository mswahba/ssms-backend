using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class User
    {
        public User()
        {
            UsersDocs = new HashSet<UsersDocs>();
            VerificationCodes = new HashSet<VerificationCode>();
            RefreshTokens = new HashSet<RefreshToken>();
            SubscribeDate = DateTime.UtcNow.AddHours(3);
            LastActive = DateTime.UtcNow.AddHours(3);
            IsDeleted = false;
        }

        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public byte? UserTypeId { get; set; }
        public byte? AccountStatusId { get; set; }
        public DateTime? SubscribeDate { get; set; }
        public DateTime? LastActive { get; set; }
        public bool? IsDeleted { get; set; }

        public Employee _Employee { get; set; }
        public Parent _Parent { get; set; }
        public Student _Student { get; set; }
        public UserType UserType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public ICollection<UsersDocs> UsersDocs { get; set; }
        public ICollection<VerificationCode> VerificationCodes { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
