using System.ComponentModel.DataAnnotations;
using SSMS.EntityModels;

namespace SSMS.ViewModels
{
  public class SignUp
  {
    [Required]
    [MinLength(10), MaxLength(10)]
    public string UserId { get; set; }
    [MinLength(6)]
    [Required]
    public string UserPassword { get; set; }
    [Required]
    [Range(0, 255)]
    public byte? UserTypeId { get; set; }
    public Employee Employee { get; set; }
    public Student Student { get; set; }
    public Parent Parent { get; set; }
  }
}