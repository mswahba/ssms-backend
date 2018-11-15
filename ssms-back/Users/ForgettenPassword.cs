using System.ComponentModel.DataAnnotations;

namespace SSMS.Users
{
    public class ForgottenPassword
    {
        [Required]
        [MinLength(6),MaxLength(10)]
        public string VerificationCode { get; set; }
        [Required]
        [MinLength(10),MaxLength(10)]
        public string UserId { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}