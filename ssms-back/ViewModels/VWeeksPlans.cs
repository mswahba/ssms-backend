using System;

public class VWeeksPlans
{
    public short weekPlanId { get; set; }
    public byte yearId { get; set; }
    public string yearNameG { get; set; }
    public string yearNameH { get; set; }
    public byte semesterId { get; set; }
    public string semesterNameAr { get; set; }
    public string semesterNameEn { get; set; }
    public short weekId { get; set; }
    public string weekNameAr { get; set; }
    public string weekNameEn { get; set; }
    public byte? dayId { get; set; }
    public string classNameAr { get; set; }
    public string classNameEn { get; set; }
    public string subjectNameAr { get; set; }
    public string subjectNameEn { get; set; }
    public DateTime? date { get; set; }
    public int? lessonId { get; set; }
    public string homework { get; set; }
    public string quiz { get; set; }
    public int timeTableId { get; set; }
    public string lessonTitle { get; set; }
    public string lessonObjectives { get; set; }
}
