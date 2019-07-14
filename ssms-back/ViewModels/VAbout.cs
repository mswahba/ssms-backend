using System;

namespace SSMS.ViewModels
{
  public class VAbout
  {
    public int AboutId { get; set; }
    public string AboutTitleAr { get; set; }
    public string AboutTitleEn { get; set; }
    public string AboutTextAr { get; set; }
    public string AboutTextEn { get; set; }
    public DateTime AboutDate { get; set; }
    public string PhotoURL { get; set; }
    public string VideoURL { get; set; }
    public bool ForCompany { get; set; }
    public byte? SchoolId { get; set; }
    public byte? StageId { get; set; }
    public int? EmpJobId { get; set; }
    public byte? CategoryId { get; set; }
  }
}
