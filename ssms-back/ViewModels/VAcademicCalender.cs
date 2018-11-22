using System;

namespace SSMS.ViewModels
{
public class VAcademicCalender
{
    public byte YearId { get; set; }
    public string YearNameG { get; set; }
    public string YearNameH { get; set; }
    public byte SemesterId { get; set; }
    public string SemesterNameAr { get; set; }
    public string SemesterNameEn { get; set; }
    public short WeekId { get; set; }
    public string WeekNameAr { get; set; }
    public string WeekNameEn { get; set; }
}
}
