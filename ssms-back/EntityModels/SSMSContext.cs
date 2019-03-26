using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SSMS.ViewModels;

namespace SSMS.EntityModels
{
  public partial class SSMSContext : DbContext
  {
    #region DbSets
    public virtual DbSet<AcademicSemester> AcademicSemesters { get; set; }
    public virtual DbSet<AcademicWeek> AcademicWeeks { get; set; }
    public virtual DbSet<AcademicYear> AcademicYears { get; set; }
    public virtual DbSet<Action> Actions { get; set; }
    public virtual DbSet<Branch> Branches { get; set; }
    public virtual DbSet<StudentClass> StudentsClasses { get; set; }
    public virtual DbSet<Classroom> Classrooms { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<District> Districts { get; set; }
    public virtual DbSet<DocType> DocTypes { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeAction> EmployeesActions { get; set; }
    public virtual DbSet<EmployeeFinance> EmployeesFinance { get; set; }
    public virtual DbSet<EmployeeHR> EmployeesHR { get; set; }
    public virtual DbSet<EmployeeJob> EmployeesJobs { get; set; }
    public virtual DbSet<HealthIssue> HealthIssues { get; set; }
    public virtual DbSet<HealthNeed> HealthNeeds { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<GradeSubject> GradesSubjects { get; set; }
    public virtual DbSet<Job> Jobs { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<JobAction> JobsActions { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<LessonFile> LessonsFiles { get; set; }
    public virtual DbSet<Major> Majors { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<NotificationType> NotificationTypes { get; set; }
    public virtual DbSet<NotificationTypeUser> NotificationTypesUsers { get; set; }
    public virtual DbSet<Parent> Parents { get; set; }
    public virtual DbSet<ParentAddress> ParentAddresses { get; set; }
    public virtual DbSet<Period> Periods { get; set; }
    public virtual DbSet<PeriodDetails> PeriodsDetails { get; set; }
    public virtual DbSet<PeriodFile> PeriodsFiles { get; set; }
    public virtual DbSet<Procedure> Procedures { get; set; }
    public virtual DbSet<Relation> Relations { get; set; }
    public virtual DbSet<Relative> Relatives { get; set; }
    public virtual DbSet<SchoolDayEvent> SchoolDayEvents { get; set; }
    public virtual DbSet<School> Schools { get; set; }
    public virtual DbSet<Stage> Stages { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<StudentProcedure> StudentsProcedures { get; set; }
    public virtual DbSet<StudentRelative> StudentsRelatives { get; set; }
    public virtual DbSet<StudentStatus> StudentsStatuses { get; set; }
    public virtual DbSet<StudentViolation> StudentsViolations { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }
    public virtual DbSet<TeacherEdu> TeachersEdu { get; set; }
    public virtual DbSet<TeacherQuorum> TeachersQuorums { get; set; }
    public virtual DbSet<TimeTable> TimeTables { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserDoc> UsersDocs { get; set; }
    public virtual DbSet<UserType> UserTypes { get; set; }
    public virtual DbSet<AccountStatus> AccountStatuses { get; set; }
    public virtual DbSet<VerificationCodeType> VerificationCodeTypes {get; set;}
    public virtual DbSet<VerificationCode> VerificationCodes {get; set;}
    public virtual DbSet<ViolationDegree> ViolationsDegrees {get; set;}
    public virtual DbSet<ViolationType> ViolationsTypes {get; set;}
    public virtual DbSet<Violation> Violations { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens {get; set;}
    public virtual DbSet<WeekPlan> WeeksPlans { get; set; }
    #endregion

    #region DbQuery
    public DbQuery<VParentFullNameAr> VParentsFullNameAr{get;set;}
    public DbQuery<VParentFullNameEn> VParentsFullNameEn{get;set;}
    public DbQuery<VAcademicCalender> VAcademicCalenders{get;set;}
    public DbQuery<VBaseEduData> VBaseEduData{get;set;}
    public DbQuery<VClassroomData> VClassroomsData{get;set;}
    public DbQuery<VEmpAction> VEmpActions{get;set;}
    public DbQuery<VEmployeeFullNameAr> VEmployeesFullNameAr{get;set;}
    public DbQuery<VEmployeeFullNameEn> VEmployeesFullNameEn{get;set;}
    public DbQuery<VEmployeeJobsData> VEmployeesJobsData{get;set;}
    public DbQuery<VProcedureOnStudentData> VProceduresOnStudentsData{get;set;}
    public DbQuery<VStudentEduData> VStudentsEduData{get;set;}
    public DbQuery<VStudentFullNameAr> VStudentsFullNameAr{get;set;}
    public DbQuery<VStudentFullNameEn> VStudentsFullNameEn{get;set;}
    public DbQuery<VStudentViolationData> VStudentsViolationsData{get;set;}
    public DbQuery<VTeacherEduData> VTeachersEduData{get;set;}
    public DbQuery<VTimeTable> VTimeTables{get;set;}
    public DbQuery<VWeekPlan> VWeeksPlans{get;set;}
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string key = "ConnectionStrings:server:assadara_ssms";
      if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer( Helpers.GetService<IConfiguration>().GetValue<string>(key));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      #region Entity [Tables] Mapping
      modelBuilder.ApplyConfiguration(new AcademicSemesterConfig());
      modelBuilder.ApplyConfiguration(new AcademicWeekConfig());
      modelBuilder.ApplyConfiguration(new AcademicYearConfig());
      modelBuilder.ApplyConfiguration(new ActionConfig());
      modelBuilder.ApplyConfiguration(new ViolationConfig());
      modelBuilder.ApplyConfiguration(new BranchConfig());
      modelBuilder.ApplyConfiguration(new StudentClassConfig());
      modelBuilder.ApplyConfiguration(new ClassroomConfig());
      modelBuilder.ApplyConfiguration(new DepartmentConfig());
      modelBuilder.ApplyConfiguration(new DocTypeConfig());
      modelBuilder.ApplyConfiguration(new EmployeeConfig());
      modelBuilder.ApplyConfiguration(new EmployeeActionConfig());
      modelBuilder.ApplyConfiguration(new EmployeeFinanceConfig());
      modelBuilder.ApplyConfiguration(new EmployeeHRConfig());
      modelBuilder.ApplyConfiguration(new EmployeeJobConfig());
      modelBuilder.ApplyConfiguration(new GradeConfig());
      modelBuilder.ApplyConfiguration(new GradeSubjectConfig());
      modelBuilder.ApplyConfiguration(new JobConfig());
      modelBuilder.ApplyConfiguration(new CountryConfig());
      modelBuilder.ApplyConfiguration(new JobActionConfig());
      modelBuilder.ApplyConfiguration(new LessonConfig());
      modelBuilder.ApplyConfiguration(new LessonFileConfig());
      modelBuilder.ApplyConfiguration(new MajorConfig());
      modelBuilder.ApplyConfiguration(new NotificationConfig());
      modelBuilder.ApplyConfiguration(new NotificationTypeConfig());
      modelBuilder.ApplyConfiguration(new NotificationTypeUserConfig());
      modelBuilder.ApplyConfiguration(new NotificationTypeUserConfig());
      modelBuilder.ApplyConfiguration(new ParentConfig());
      modelBuilder.ApplyConfiguration(new PeriodConfig());
      modelBuilder.ApplyConfiguration(new PeriodDetailsConfig());
      modelBuilder.ApplyConfiguration(new PeriodFileConfig());
      modelBuilder.ApplyConfiguration(new ProcedureConfig());
      modelBuilder.ApplyConfiguration(new SchoolDayEventConfig());
      modelBuilder.ApplyConfiguration(new SchoolConfig());
      modelBuilder.ApplyConfiguration(new StageConfig());
      modelBuilder.ApplyConfiguration(new StudentConfig());
      modelBuilder.ApplyConfiguration(new StudentProcedureConfig());
      modelBuilder.ApplyConfiguration(new StudentStatusConfig());
      modelBuilder.ApplyConfiguration(new StudentViolationConfig());
      modelBuilder.ApplyConfiguration(new SubjectConfig());
      modelBuilder.ApplyConfiguration(new TeacherEduConfig());
      modelBuilder.ApplyConfiguration(new TeacherQuorumConfig());
      modelBuilder.ApplyConfiguration(new TimeTableConfig());
      modelBuilder.ApplyConfiguration(new UserConfig());
      modelBuilder.ApplyConfiguration(new UserDocConfig());
      modelBuilder.ApplyConfiguration(new UserTypeConfig());
      modelBuilder.ApplyConfiguration(new AccountStatusConfig());
      modelBuilder.ApplyConfiguration(new VerificationCodeTypeConfig());
      modelBuilder.ApplyConfiguration(new VerificationCodeConfig());
      modelBuilder.ApplyConfiguration(new RefreshTokenConfig());
      modelBuilder.ApplyConfiguration(new RelationConfig());
      modelBuilder.ApplyConfiguration(new RelativeConfig());
      modelBuilder.ApplyConfiguration(new WeekPlanConfig());
      #endregion

      #region Query [Views]  Mapping
      modelBuilder.Query<VAcademicCalender>().ToView("v_AcademicCalenders");
      modelBuilder.Query<VBaseEduData>().ToView("v_BaseEduData");
      modelBuilder.Query<VClassroomData>().ToView("v_ClassroomsData");
      modelBuilder.Query<VEmpAction>().ToView("v_EmployeesActions");
      modelBuilder.Query<VEmployeeFullNameAr>().ToView("v_EmployeesFullNameAr");
      modelBuilder.Query<VEmployeeFullNameEn>().ToView("v_EmployeesFullNameEn");
      modelBuilder.Query<VEmployeeJobsData>().ToView("v_EmpoyeesJobsData");
      modelBuilder.Query<VParentFullNameAr>().ToView("v_ParentsFullNameAr");
      modelBuilder.Query<VParentFullNameEn>().ToView("v_ParentsFullNameEn");
      modelBuilder.Query<VProcedureOnStudentData>().ToView("v_ProceduresOnStudentsData");
      modelBuilder.Query<VStudentEduData>().ToView("v_StudentsEduData");
      modelBuilder.Query<VStudentFullNameAr>().ToView("v_StudentsFullNameAr");
      modelBuilder.Query<VStudentFullNameEn>().ToView("v_StudentsFullNameEn");
      modelBuilder.Query<VStudentViolationData>().ToView("v_StudentsViolationsData");
      modelBuilder.Query<VTeacherEduData>().ToView("v_TeachersEduData");
      modelBuilder.Query<VTimeTable>().ToView("v_TimeTables");
      modelBuilder.Query<VWeekPlan>().ToView("v_WeeksPlans");
      #endregion

    }
  }
}