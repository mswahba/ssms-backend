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
    public virtual DbSet<BehavioralViolation> BehavioralViolations { get; set; }
    public virtual DbSet<Branch> Branches { get; set; }
    public virtual DbSet<ClassStudent> ClassesStudents { get; set; }
    public virtual DbSet<Classrooms> Classrooms { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<DocType> DocTypes { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeAction> EmployeesActions { get; set; }
    public virtual DbSet<EmployeeFinance> EmployeesFinance { get; set; }
    public virtual DbSet<EmployeeHR> EmployeesHr { get; set; }
    public virtual DbSet<EmployeeJob> EmployeesJobs { get; set; }
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
    public virtual DbSet<Period> Periods { get; set; }
    public virtual DbSet<PeriodDetails> PeriodsDetails { get; set; }
    public virtual DbSet<PeriodFile> PeriodsFiles { get; set; }
    public virtual DbSet<RemedialProcedure> RemedialProcedures { get; set; }
    public virtual DbSet<SchoolDayEvent> SchoolDayEvents { get; set; }
    public virtual DbSet<School> Schools { get; set; }
    public virtual DbSet<Stage> Stages { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<StudentProcedure> StudentsProcedures { get; set; }
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
      modelBuilder.ApplyConfiguration(new BehavioralViolationConfig());
      modelBuilder.ApplyConfiguration(new BranchConfig());
      modelBuilder.ApplyConfiguration(new ClassStudentConfig());
      modelBuilder.ApplyConfiguration(new ClassroomsConfig());
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

      modelBuilder.Entity<Period>(entity =>
      {
        entity.HasKey(e => e.PeriodId);

        entity.ToTable("periods");

        entity.Property(e => e.PeriodId)
                  .HasColumnName("periodId")
                  .ValueGeneratedNever();

        entity.Property(e => e.ClasseroomId).HasColumnName("classeroomId");

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.EndTime).HasColumnName("endTime");

        entity.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

        entity.Property(e => e.PeriodDate)
                  .HasColumnName("periodDate")
                  .HasColumnType("date");

        entity.Property(e => e.SchoolDayEventId).HasColumnName("schoolDayEventId");

        entity.Property(e => e.SemesterId).HasColumnName("semesterId");

        entity.Property(e => e.StartTime).HasColumnName("startTime");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Classeroom)
                  .WithMany(p => p.Periods)
                  .HasForeignKey(d => d.ClasseroomId)
                  .HasConstraintName("FK_periods_classrooms");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.Periods)
                  .HasForeignKey(d => d.EmpJobId)
                  .HasConstraintName("FK_periods_employeesJobs");

        entity.HasOne(d => d.GradeSubject)
                  .WithMany(p => p.Periods)
                  .HasForeignKey(d => d.GradeSubjectId)
                  .HasConstraintName("FK_periods_gradesSubjects");

        entity.HasOne(d => d.SchoolDayEvent)
                  .WithMany(p => p.Periods)
                  .HasForeignKey(d => d.SchoolDayEventId)
                  .HasConstraintName("FK_periods_schoolDayEvents");

        entity.HasOne(d => d.Semester)
                  .WithMany(p => p.Periods)
                  .HasForeignKey(d => d.SemesterId)
                  .HasConstraintName("FK_periods_academicSemesters");
      });

      modelBuilder.Entity<PeriodDetails>(entity =>
      {
        entity.HasKey(e => e.PeriodDetailId);

        entity.ToTable("periodsDetails");

        entity.Property(e => e.PeriodDetailId)
                  .HasColumnName("periodDetailId")
                  .ValueGeneratedNever();

        entity.Property(e => e.AttandanceTime).HasColumnName("attandanceTime");

        entity.Property(e => e.HomeworkRate).HasColumnName("homeworkRate");

        entity.Property(e => e.IsEalryExit).HasColumnName("isEalryExit");

        entity.Property(e => e.LeaveTime).HasColumnName("leaveTime");

        entity.Property(e => e.Notes).HasColumnName("notes");

        entity.Property(e => e.ParticipationsCount).HasColumnName("participationsCount");

        entity.Property(e => e.ParticipationsQuality).HasColumnName("participationsQuality");

        entity.Property(e => e.PeriodId).HasColumnName("periodId");

        entity.Property(e => e.StudentId)
                  .HasColumnName("studentId")
                  .HasColumnType("char(10)");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Period)
                  .WithMany(p => p.PeriodsDetails)
                  .HasForeignKey(d => d.PeriodId)
                  .HasConstraintName("FK_periodsDetails_periods");

        entity.HasOne(d => d.Student)
                  .WithMany(p => p.PeriodsDetails)
                  .HasForeignKey(d => d.StudentId)
                  .HasConstraintName("FK_periodsDetails_students");
      });

      modelBuilder.Entity<PeriodFile>(entity =>
      {
        entity.HasKey(e => e.PeriodFileId);

        entity.ToTable("periodsFiles");

        entity.Property(e => e.PeriodFileId)
                  .HasColumnName("periodFileId")
                  .ValueGeneratedNever();

        entity.Property(e => e.CreatedAt)
                  .HasColumnName("createdAt")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

        entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

        entity.Property(e => e.FilePath).HasColumnName("filePath");

        entity.Property(e => e.IsExternalLink).HasColumnName("isExternalLink");

        entity.Property(e => e.WeekPlanId).HasColumnName("weekPlanId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.DocType)
                  .WithMany(p => p.PeriodsFiles)
                  .HasForeignKey(d => d.DocTypeId)
                  .HasConstraintName("FK_periodsFiles_docTypes");

        entity.HasOne(d => d.WeekPlan)
                  .WithMany(p => p.PeriodsFiles)
                  .HasForeignKey(d => d.WeekPlanId)
                  .HasConstraintName("FK_periodsFiles_weeksPlans");
      });

      modelBuilder.Entity<RemedialProcedure>(entity =>
      {
        entity.HasKey(e => e.ProcedureId);

        entity.ToTable("remedialProcedures");

        entity.Property(e => e.ProcedureId)
                  .HasColumnName("procedureId")
                  .ValueGeneratedNever();

        entity.Property(e => e.CategoryId).HasColumnName("categoryId");

        entity.Property(e => e.ProcedureNameAr)
                  .HasColumnName("procedureNameAr")
                  .HasMaxLength(150);

        entity.Property(e => e.ProcedureNameEn)
                  .HasColumnName("procedureNameEn")
                  .HasMaxLength(150);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      });

      modelBuilder.Entity<SchoolDayEvent>(entity =>
      {
        entity.HasKey(e => e.SchoolDayEventId);

        entity.ToTable("schoolDayEvents");

        entity.Property(e => e.SchoolDayEventId)
                  .HasColumnName("schoolDayEventId")
                  .ValueGeneratedNever();

        entity.Property(e => e.DayId).HasColumnName("dayId");

        entity.Property(e => e.EndTime)
                  .HasColumnName("endTime")
                  .HasColumnType("time(0)");

        entity.Property(e => e.EventNameAr)
                  .HasColumnName("eventNameAr")
                  .HasMaxLength(50);

        entity.Property(e => e.EventNameEn)
                  .HasColumnName("eventNameEn")
                  .HasMaxLength(50);

        entity.Property(e => e.StageId).HasColumnName("stageId");

        entity.Property(e => e.StartTime)
                  .HasColumnName("startTime")
                  .HasColumnType("time(0)");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Stage)
                  .WithMany(p => p.SchoolDayEvents)
                  .HasForeignKey(d => d.StageId)
                  .HasConstraintName("FK_schoolDayEvents_stages");
      });

      modelBuilder.Entity<School>(entity =>
      {
        entity.HasKey(e => e.SchoolId);

        entity.ToTable("schools");

        entity.Property(e => e.SchoolId).HasColumnName("schoolID");

        entity.Property(e => e.Address)
                  .HasColumnName("address")
                  .HasMaxLength(250);

        entity.Property(e => e.ComNum)
                  .HasColumnName("comNum")
                  .HasMaxLength(50);

        entity.Property(e => e.IsActive).HasColumnName("isActive");

        entity.Property(e => e.SchoolNameAr)
                  .HasColumnName("schoolNameAr")
                  .HasMaxLength(150);

        entity.Property(e => e.SchoolNameEn)
                  .HasColumnName("schoolNameEn")
                  .HasMaxLength(150);

        entity.Property(e => e.StartDate)
                  .HasColumnName("startDate")
                  .HasColumnType("date");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      });

      modelBuilder.Entity<Stage>(entity =>
      {
        entity.HasKey(e => e.StageId);

        entity.ToTable("stages");

        entity.Property(e => e.StageId).HasColumnName("stageId");

        entity.Property(e => e.BranchId).HasColumnName("branchId");

        entity.Property(e => e.StageNameAr)
                  .HasColumnName("stageNameAr")
                  .HasMaxLength(25);

        entity.Property(e => e.StageNameEn)
                  .HasColumnName("stageNameEn")
                  .HasMaxLength(25);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Branch)
                  .WithMany(p => p.Stages)
                  .HasForeignKey(d => d.BranchId)
                  .HasConstraintName("FK_stages_branches");
      });

      modelBuilder.Entity<Student>(entity =>
      {
        entity.HasKey(e => e.StudentId);

        entity.ToTable("students");

        entity.Property(e => e.StudentId)
                  .HasColumnName("studentId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        entity.Property(e => e.BirthDateG)
                  .HasColumnName("birthDateG")
                  .HasColumnType("date");

        entity.Property(e => e.BirthDateH)
                  .HasColumnName("birthDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.BirthPlace)
                  .HasColumnName("birthPlace")
                  .HasMaxLength(50);

        entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .HasMaxLength(50);

        entity.Property(e => e.FNameAr)
                  .HasColumnName("fNameAr")
                  .HasMaxLength(20);
        entity.Property(e => e.MNameAr)
                  .HasColumnName("mNameAr")
                  .HasMaxLength(20);
        entity.Property(e => e.GNameAr)
                  .HasColumnName("gNameAr")
                  .HasMaxLength(20);
        entity.Property(e => e.LNameAr)
                  .HasColumnName("lNameAr")
                  .HasMaxLength(20);

        entity.Property(e => e.FNameEn)
                  .HasColumnName("fNameEn")
                  .HasMaxLength(20);
        entity.Property(e => e.MNameEn)
                  .HasColumnName("mNameEn")
                  .HasMaxLength(20);
        entity.Property(e => e.GNameEn)
                  .HasColumnName("gNameEn")
                  .HasMaxLength(20);
        entity.Property(e => e.LNameEn)
                  .HasColumnName("lNameEn")
                  .HasMaxLength(20);

        entity.Property(e => e.Gender).HasColumnName("gender");

        entity.Property(e => e.IdExpireDateG).HasColumnType("date");

        entity.Property(e => e.IdExpireDateH)
                  .HasColumnName("idExpireDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.IdIssuePlace).HasMaxLength(50);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.Property(e => e.Mobile)
                  .HasColumnName("mobile")
                  .HasMaxLength(15);

        entity.Property(e => e.MobileMother)
                  .HasColumnName("mobileMother")
                  .HasMaxLength(15);

        entity.Property(e => e.ParentId)
                  .HasColumnName("parentId")
                  .HasColumnType("char(10)");

        entity.Property(e => e.PreviousSchool)
                  .HasColumnName("previousSchool")
                  .HasMaxLength(100);

        entity.Property(e => e.SpecialNeeds).HasColumnName("specialNeeds");

        entity.Property(e => e.CountryId).HasColumnName("countryId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Parent)
                  .WithMany(p => p.Students)
                  .HasForeignKey(d => d.ParentId)
                  .HasConstraintName("FK_students_parents");

        entity.HasOne(s => s._Student)
                  .WithOne(p => p._Student)
                  .HasForeignKey<Student>(s => s.StudentId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_students_users");

        entity.HasOne(s => s.Country)
                  .WithMany(c => c.Students)
                  .HasForeignKey(s => s.CountryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_students_countries");
      });

      modelBuilder.Entity<StudentProcedure>(entity =>
      {
        entity.HasKey(e => e.StudentProcedureId);

        entity.ToTable("studentsProcedures");

        entity.Property(e => e.StudentProcedureId)
                  .HasColumnName("studentProcedureId")
                  .ValueGeneratedNever();

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.ProcedureDate)
                  .HasColumnName("procedureDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.ProcedureId).HasColumnName("procedureId");

        entity.Property(e => e.StudentViolationId).HasColumnName("studentViolationId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.StudentsProcedures)
                  .HasForeignKey(d => d.EmpJobId)
                  .HasConstraintName("FK_studentsProcedures_employeesJobs");

        entity.HasOne(d => d.Procedure)
                  .WithMany(p => p.StudentsProcedures)
                  .HasForeignKey(d => d.ProcedureId)
                  .HasConstraintName("FK_studentsProcedures_remedialProcedures");

        entity.HasOne(d => d.StudentViolation)
                  .WithMany(p => p.StudentsProcedures)
                  .HasForeignKey(d => d.StudentViolationId)
                  .HasConstraintName("FK_studentsProcedures_studentsViolations");
      });

      modelBuilder.Entity<StudentViolation>(entity =>
      {
        entity.HasKey(e => e.StudentViolationId);

        entity.ToTable("studentsViolations");

        entity.Property(e => e.StudentViolationId)
                  .HasColumnName("studentViolationId")
                  .ValueGeneratedNever();

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.StudentId)
                  .HasColumnName("studentId")
                  .HasColumnType("char(10)");

        entity.Property(e => e.ViolationDate)
                  .HasColumnName("violationDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.ViolationId).HasColumnName("violationId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.StudentsViolations)
                  .HasForeignKey(d => d.EmpJobId)
                  .HasConstraintName("FK_studentsViolations_employeesJobs");

        entity.HasOne(d => d.Student)
                  .WithMany(p => p.StudentsViolations)
                  .HasForeignKey(d => d.StudentId)
                  .HasConstraintName("FK_studentsViolations_students");

        entity.HasOne(d => d.Violation)
                  .WithMany(p => p.StudentsViolations)
                  .HasForeignKey(d => d.ViolationId)
                  .HasConstraintName("FK_studentsViolations_behavioralViolations");
      });

      modelBuilder.Entity<Subject>(entity =>
      {
        entity.HasKey(e => e.SubjectId);

        entity.ToTable("subjects");

        entity.Property(e => e.SubjectId).HasColumnName("subjectId");

        entity.Property(e => e.MajorId).HasColumnName("majorId");

        entity.Property(e => e.ShortNameAr)
                  .HasColumnName("shortNameAr")
                  .HasMaxLength(5);

        entity.Property(e => e.ShortNameEn)
                  .HasColumnName("shortNameEn")
                  .HasMaxLength(5);

        entity.Property(e => e.SubjectNameAr)
                  .HasColumnName("subjectNameAr")
                  .HasMaxLength(25);

        entity.Property(e => e.SubjectNameEn)
                  .HasColumnName("subjectNameEn")
                  .HasMaxLength(25);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Major)
                  .WithMany(p => p.Subjects)
                  .HasForeignKey(d => d.MajorId)
                  .HasConstraintName("FK_subjects_majors");
      });

      modelBuilder.Entity<TeacherEdu>(entity =>
      {
        entity.HasKey(e => new { e.EmpJobId, e.GradeSubjectId });

        entity.ToTable("teachersEdu");

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

        entity.Property(e => e.ClassroomIds)
                  .HasColumnName("classroomIds")
                  .HasMaxLength(150)
                  .IsUnicode(false);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.TeachersEdu)
                  .HasForeignKey(d => d.EmpJobId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_teachersEdu_employeesJobs");

        entity.HasOne(d => d.GradeSubject)
                  .WithMany(p => p.TeachersEdu)
                  .HasForeignKey(d => d.GradeSubjectId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_teachersEdu_gradesSubjects");
      });

      modelBuilder.Entity<TeacherQuorum>(entity =>
      {
        entity.HasKey(e => e.TeacherQuorumId);

        entity.ToTable("teachersQuorums");

        entity.Property(e => e.TeacherQuorumId)
                  .HasColumnName("teacherQuorumId")
                  .ValueGeneratedNever();

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.PeriodsQuorum).HasColumnName("periodsQuorum");

        entity.Property(e => e.SemesterId).HasColumnName("semesterId");

        entity.Property(e => e.SubstituteQuorum).HasColumnName("substituteQuorum");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.TeachersQuorums)
                  .HasForeignKey(d => d.EmpJobId)
                  .HasConstraintName("FK_teachersQuorums_employeesJobs");

        entity.HasOne(d => d.Semester)
                  .WithMany(p => p.TeachersQuorums)
                  .HasForeignKey(d => d.SemesterId)
                  .HasConstraintName("FK_teachersQuorums_academicSemesters");
      });

      modelBuilder.Entity<TimeTable>(entity =>
      {
        entity.ToTable("timeTables");

        entity.Property(e => e.TimeTableId)
                  .HasColumnName("timeTableId")
                  .ValueGeneratedNever();

        entity.Property(e => e.ClassroomId).HasColumnName("classroomId");

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

        entity.Property(e => e.SchoolDayEventId).HasColumnName("schoolDayEventId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.TimeTable)
                  .HasForeignKey(d => d.EmpJobId)
                  .HasConstraintName("FK_timeTable_employeesJobs");

        entity.HasOne(d => d.GradeSubject)
                  .WithMany(p => p.TimeTable)
                  .HasForeignKey(d => d.GradeSubjectId)
                  .HasConstraintName("FK_timeTable_gradesSubjects");

        entity.HasOne(d => d.SchoolDayEvent)
                  .WithMany(p => p.TimeTable)
                  .HasForeignKey(d => d.SchoolDayEventId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_timeTable_schoolDayEvents");
      });

      modelBuilder.ApplyConfiguration(new UserConfig());

      modelBuilder.Entity<UserDoc>(entity =>
      {
        entity.HasKey(e => e.UserDocId);

        entity.ToTable("usersDocs");

        entity.Property(e => e.UserDocId)
                  .HasColumnName("userDocId")
                  .ValueGeneratedNever();

        entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

        entity.Property(e => e.FilePath)
                  .HasColumnName("filePath")
                  .HasMaxLength(15);

        entity.Property(e => e.UserId)
                  .IsRequired()
                  .HasColumnName("userId")
                  .HasColumnType("char(10)");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.DocType)
                  .WithMany(p => p.UsersDocs)
                  .HasForeignKey(d => d.DocTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_usersDocs_docTypes");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.UsersDocs)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_usersDocs_users");
      });

      modelBuilder.Entity<UserType>(entity =>
      {
        entity.HasKey(e => e.UserTypeId);

        entity.ToTable("userTypes");

        entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

        entity.Property(e => e.UserTypeName)
                  .HasColumnName("userTypeName")
                  .HasMaxLength(25);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      });

      modelBuilder.Entity<AccountStatus>(entity =>
      {
        entity.HasKey(e => e.StatusId);

        entity.ToTable("accountStatus");

        entity.Property(e => e.StatusId).HasColumnName("statusId");

        entity.Property(e => e.StatusEn)
                  .HasColumnName("statusEn")
                  .HasMaxLength(20);

        entity.Property(e => e.StatusAr)
                  .HasColumnName("statusAr")
                  .HasMaxLength(20);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      });

      modelBuilder.Entity<VerificationCodeType>(entity =>
      {
        entity.HasKey(e => e.CodeTypeId);

        entity.ToTable("verificationCodeTypes");

        entity.Property(e => e.CodeTypeId).HasColumnName("codeTypeId");

        entity.Property(e => e.CodeType)
                  .HasColumnName("codeType")
                  .HasMaxLength(25);

        entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .HasColumnType("varchar(MAX)");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      });

      modelBuilder.Entity<VerificationCode>(entity =>
      {
        entity.HasKey(e => e.CodeId);

        entity.ToTable("verificationCodes");

        entity.Property(e => e.CodeId).HasColumnName("codeId");

        entity.Property(e => e.Code)
                  .HasColumnName("code")
                  .HasMaxLength(10);

        entity.Property(e => e.UserId)
                  .HasColumnName("userId")
                  .HasMaxLength(10);

        entity.Property(e => e.SentTime).HasColumnName("sentTime");

        entity.Property(e => e.CodeTypeId).HasColumnName("codeTypeId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(vc => vc.User)
                  .WithMany(u => u.VerificationCodes)
                  .HasForeignKey(vc => vc.UserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_users_verificationCodes");

        entity.HasOne(vc => vc.VerificationCodeType)
                  .WithMany(vct => vct.VerificationCodes)
                  .HasForeignKey(vc => vc.CodeTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_verificationCodeTypes_verificationCodes");

      });

      modelBuilder.Entity<RefreshToken>(entity =>
      {
        entity.HasKey(e => e.TokenId);

        entity.ToTable("refreshTokens");

        entity.Property(e => e.TokenId).HasColumnName("tokenId");

        entity.Property(e => e.Token)
              .HasColumnName("token")
              .HasMaxLength(32);

        entity.Property(e => e.DeviceInfo)
                  .HasColumnName("deviceInfo")
                  .HasColumnType("varchar(MAX)");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId")
                  .HasMaxLength(10);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(rt => rt.User)
                  .WithMany(u => u.RefreshTokens)
                  .HasForeignKey(rt => rt.UserId)
                  .HasConstraintName("FK_users_refreshTokens");
      });

      modelBuilder.Entity<WeekPlan>(entity =>
      {
        entity.HasKey(e => e.WeekPlanId);

        entity.ToTable("weeksPlans");

        entity.Property(e => e.WeekPlanId)
                  .HasColumnName("weekPlanId")
                  .ValueGeneratedNever();

        entity.Property(e => e.Date)
                  .HasColumnName("date")
                  .HasColumnType("date");

        entity.Property(e => e.Homework).HasColumnName("homework");

        entity.Property(e => e.LessonId).HasColumnName("lessonId");

        entity.Property(e => e.Quiz).HasColumnName("quiz");

        entity.Property(e => e.TimeTableId).HasColumnName("timeTableId");

        entity.Property(e => e.WeekId).HasColumnName("weekId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.HasOne(d => d.Lesson)
                  .WithMany(p => p.WeeksPlans)
                  .HasForeignKey(d => d.LessonId)
                  .HasConstraintName("FK_weeksPlans_lessons");

        entity.HasOne(d => d.TimeTable)
                  .WithMany(p => p.WeeksPlans)
                  .HasForeignKey(d => d.TimeTableId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_weeksPlans_timeTable");

        entity.HasOne(d => d.Week)
                  .WithMany(p => p.WeeksPlans)
                  .HasForeignKey(d => d.WeekId)
                  .HasConstraintName("FK_weeksPlans_academicWeeks");
      });

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