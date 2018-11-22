using System;

namespace SSMS.ViewModels
{
public class VTeacherEduData
{
    public string UserId { get; set; }
    public byte StatusId { get; set; }
    public string StatusAr { get; set; }
    public string StatusEn { get; set; }
    public int EmpJobId { get; set; }
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
    public byte MajorId { get; set; }
    public string MajorNameAr { get; set; }
    public string MajorNameEn { get; set; }
    public string ClassroomIds { get; set; }
    public byte? PeriodsQuorum { get; set; }
    public byte? SubstituteQuorum { get; set; }
    public byte SemesterId { get; set; }
    public string SemesterNameAr { get; set; }
    public string SemesterNameEn { get; set; }
    public byte YearId { get; set; }
    public string YearNameG { get; set; }
    public string YearNameH { get; set; }
    public short GradeSubjectId { get; set; }
    public byte SubjectId { get; set; }
    public string SubjectNameAr { get; set; }
    public string SubjectNameEn { get; set; }
}
}
