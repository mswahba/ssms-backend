using System;

namespace SSMS.ViewModels
{
  public class _VUser
  {
    public string UserId { get; set; }
    public byte? UserTypeId { get; set; }
    public byte? AccountStatusId { get; set; }
    public DateTime? SubscribeDate { get; set; }
    public DateTime? LastActive { get; set; }
    public bool? IsDeleted { get; set; }
  }
}