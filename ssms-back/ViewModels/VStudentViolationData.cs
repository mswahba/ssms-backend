using System;

namespace SSMS.ViewModels
{
public class VStudentViolationData
{
    public string StudentId { get; set; }
    public string StudentNameAr { get; set; }
    public string StudentNameEn { get; set; }
    public string SchoolNameAr { get; set; }
    public string SchoolNameEn { get; set; }
    public string BranchNameAr { get; set; }
    public string BranchNameEn { get; set; }
    public string StageNameAr { get; set; }
    public string StageNameEn { get; set; }
    public string GradeNameAr { get; set; }
    public string GradeNameEn { get; set; }
    public string ClassNameAr { get; set; }
    public string ClassNameEn { get; set; }
    public short ViolationId { get; set; }
    public string ViolationNameAr { get; set; }
    public string ViolationNameEn { get; set; }
    public byte? CategoryId { get; set; }
    public DateTime? ViolationDate { get; set; }
    public int StudentViolationId { get; set; }
}
}
