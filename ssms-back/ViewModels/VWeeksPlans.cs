using System;

namespace SSMS.ViewModels
{
public class VWeekPlan
{
    public short WeekPlanId { get; set; }
    public byte YearId { get; set; }
    public string YearNameG { get; set; }
    public string YearNameH { get; set; }
    public byte SemesterId { get; set; }
    public string SemesterNameAr { get; set; }
    public string SemesterNameEn { get; set; }
    public short WeekId { get; set; }
    public string WeekNameAr { get; set; }
    public string WeekNameEn { get; set; }
    public byte? DayId { get; set; }
    public string ClassNameAr { get; set; }
    public string ClassNameEn { get; set; }
    public string SubjectNameAr { get; set; }
    public string SubjectNameEn { get; set; }
    public DateTime? Date { get; set; }
    public int? LessonId { get; set; }
    public string Homework { get; set; }
    public string Quiz { get; set; }
    public int TimeTableId { get; set; }
    public string LessonTitle { get; set; }
    public string LessonObjectives { get; set; }
}
}