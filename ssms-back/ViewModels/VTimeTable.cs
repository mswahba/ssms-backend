using System;

namespace SSMS.ViewModels
{
public class VTimeTable
{
    public byte? DayId { get; set; }
    public string ClassNameAr { get; set; }
    public string ClassNameEn { get; set; }
    public string EventNameAr { get; set; }
    public string EventNameEn { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string SubjectNameAr { get; set; }
    public string SubjectNameEn { get; set; }
    public int TimeTableId { get; set; }
}
}
