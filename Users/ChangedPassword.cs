using System.ComponentModel.DataAnnotations;

namespace SSMS.Users
{
    public class ChangedPassword
    {
        [Required]
        [MinLength(10),MaxLength(10)]
        public string UserId { get; set; }
        [MinLength(6)]
        [Required]
        public string OldPassword { get; set; }
        [MinLength(6)]
        [Required]
        public string NewPassword { get; set; }
    }
}