using System.ComponentModel.DataAnnotations;

namespace SSMS.Users.Parents
{
    public class ChangedParentId
    {
        [Required]
        [MinLength(10), MaxLength(10)]
        public string ParentOldId { get; set; }
        
        [Required]
        [MinLength(10), MaxLength(10)]
        public string ParentNewId { get; set; }
    }
}