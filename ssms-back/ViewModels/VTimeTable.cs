using System;

public class VTimeTable
{
    public byte? dayId { get; set; }
    public string classNameAr { get; set; }
    public string classNameEn { get; set; }
    public string eventNameAr { get; set; }
    public string eventNameEn { get; set; }
    public TimeSpan? startTime { get; set; }
    public TimeSpan? endTime { get; set; }
    public string subjectNameAr { get; set; }
    public string subjectNameEn { get; set; }
    public int timeTableId { get; set; }
}
