using System.ComponentModel.DataAnnotations;

namespace SSMS.Users
{
    public class SignIn
    {
        [Required]
        [MinLength(10),MaxLength(10)]
        public string UserId { get; set; }
        [MinLength(6)]
        [Required]
        public string UserPassword { get; set; }
    }
}