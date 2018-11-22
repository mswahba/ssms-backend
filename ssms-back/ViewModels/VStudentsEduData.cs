using System;

namespace SSMS.ViewModels
{
public class VStudentEduData
{
    public string StudentId { get; set; }
    public string StudentNameAr { get; set; }
    public string StudentNameEn { get; set; }
    public byte SchoolID { get; set; }
    public string SchoolNameAr { get; set; }
    public string SchoolNameEn { get; set; }
    public byte BranchId { get; set; }
    public string BranchNameAr { get; set; }
    public string BranchNameEn { get; set; }
    public byte StageId { get; set; }
    public string StageNameAr { get; set; }
    public string StageNameEn { get; set; }
    public byte GradeId { get; set; }
    public string GradeNameAr { get; set; }
    public string GradeNameEn { get; set; }
    public short ClassroomId { get; set; }
    public string ClassNameAr { get; set; }
    public string ClassNameEn { get; set; }
    public int ClassStudentId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public byte YearId { get; set; }
    public string YearNameG { get; set; }
    public string YearNameH { get; set; }
    public DateTime? YearStartDateG { get; set; }
    public string YearStartDateH { get; set; }
    public DateTime? YearEndDateG { get; set; }
    public string YearEndDateH { get; set; }
}
}
