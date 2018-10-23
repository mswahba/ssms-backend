using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
    public virtual DbSet<EmployeeHr> EmployeesHr { get; set; }
    public virtual DbSet<EmployeeJob> EmployeesJobs { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<GradesSubjects> GradesSubjects { get; set; }
    public virtual DbSet<Job> Jobs { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<JobAction> JobsActions { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<LessonFile> LessonsFiles { get; set; }
    public virtual DbSet<Major> Majors { get; set; }
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
    public virtual DbSet<UsersDocs> UsersDocs { get; set; }
    public virtual DbSet<UserType> UserTypes { get; set; }
    public virtual DbSet<WeekPlan> WeeksPlans { get; set; }

    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("appsettings.json".GetJsonValue<AppSettings>("ConStr"));
      }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AcademicSemester>(entity =>
      {
        entity.HasKey(e => e.SemesterId);

        entity.ToTable("academicSemesters");

        entity.Property(e => e.SemesterId).HasColumnName("semesterId");

        entity.Property(e => e.SemesterEndDateG)
                  .HasColumnName("semesterEndDateG")
                  .HasColumnType("date");

        entity.Property(e => e.SemesterEndDateH)
                  .HasColumnName("semesterEndDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.SemesterNameAr)
                  .HasColumnName("semesterNameAr")
                  .HasMaxLength(25);

        entity.Property(e => e.SemesterNameEn)
                  .HasColumnName("semesterNameEn")
                  .HasMaxLength(25);

        entity.Property(e => e.SemesterStartDateG)
                  .HasColumnName("semesterStartDateG")
                  .HasColumnType("date");

        entity.Property(e => e.SemesterStartDateH)
                  .HasColumnName("semesterStartDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.YearId).HasColumnName("yearId");

        entity.HasOne(d => d.Year)
                  .WithMany(p => p.AcademicSemesters)
                  .HasForeignKey(d => d.YearId)
                  .HasConstraintName("FK_academicSemesters_academicYears");
      });

      modelBuilder.Entity<AcademicWeek>(entity =>
      {
        entity.HasKey(e => e.WeekId);

        entity.ToTable("academicWeeks");

        entity.Property(e => e.WeekId)
                  .HasColumnName("weekId")
                  .ValueGeneratedNever();

        entity.Property(e => e.SemesterId).HasColumnName("semesterId");

        entity.Property(e => e.WeekEndDateG).HasColumnType("date");

        entity.Property(e => e.WeekEndDateH).HasColumnType("nchar(10)");

        entity.Property(e => e.WeekNameAr)
                  .HasColumnName("weekNameAr")
                  .HasMaxLength(25);

        entity.Property(e => e.WeekNameEn)
                  .HasColumnName("weekNameEn")
                  .HasMaxLength(25);

        entity.Property(e => e.WeekStartDateG)
                  .HasColumnName("weekStartDateG")
                  .HasColumnType("date");

        entity.Property(e => e.WeekStartDateH)
                  .HasColumnName("weekStartDateH")
                  .HasColumnType("nchar(10)");

        entity.HasOne(d => d.Semester)
                  .WithMany(p => p.AcademicWeeks)
                  .HasForeignKey(d => d.SemesterId)
                  .HasConstraintName("FK_academicWeeks_academicSemesters");
      });

      modelBuilder.Entity<AcademicYear>(entity =>
      {
        entity.HasKey(e => e.YearId);

        entity.ToTable("academicYears");

        entity.Property(e => e.YearId).HasColumnName("yearId");

        entity.Property(e => e.YearEndDateG)
                  .HasColumnName("yearEndDateG")
                  .HasColumnType("date");

        entity.Property(e => e.YearEndDateH)
                  .HasColumnName("yearEndDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.YearNameG)
                  .HasColumnName("yearNameG")
                  .HasMaxLength(10);

        entity.Property(e => e.YearNameH)
                  .HasColumnName("yearNameH")
                  .HasMaxLength(10);

        entity.Property(e => e.YearStartDateG)
                  .HasColumnName("yearStartDateG")
                  .HasColumnType("date");

        entity.Property(e => e.YearStartDateH)
                  .HasColumnName("yearStartDateH")
                  .HasColumnType("nchar(10)");
      });

      modelBuilder.Entity<Action>(entity =>
      {
        entity.HasKey(e => e.ActionId);

        entity.ToTable("actions");

        entity.Property(e => e.ActionId)
                  .HasColumnName("actionId")
                  .ValueGeneratedNever();

        entity.Property(e => e.ActionNameAr)
                  .HasColumnName("actionNameAr")
                  .HasMaxLength(100);

        entity.Property(e => e.ActionNameEn)
                  .HasColumnName("actionNameEn")
                  .HasMaxLength(100);

        entity.Property(e => e.ActionUrl)
                  .HasColumnName("actionUrl")
                  .HasMaxLength(100);
      });

      modelBuilder.Entity<BehavioralViolation>(entity =>
      {
        entity.HasKey(e => e.ViolationId);

        entity.ToTable("behavioralViolations");

        entity.Property(e => e.ViolationId)
                  .HasColumnName("violationId")
                  .ValueGeneratedNever();

        entity.Property(e => e.CategoryId).HasColumnName("categoryId");

        entity.Property(e => e.ViolationNameAr)
                  .HasColumnName("violationNameAr")
                  .HasMaxLength(150);

        entity.Property(e => e.ViolationNameEn)
                  .HasColumnName("violationNameEn")
                  .HasMaxLength(150);
      });

      modelBuilder.Entity<Branch>(entity =>
      {
        entity.HasKey(e => e.BranchId);

        entity.ToTable("branches");

        entity.Property(e => e.BranchId).HasColumnName("branchId");

        entity.Property(e => e.BranchNameAr)
                  .HasColumnName("branchNameAr")
                  .HasMaxLength(8);

        entity.Property(e => e.BranchNameEn)
                  .HasColumnName("branchNameEn")
                  .HasMaxLength(8);

        entity.Property(e => e.SchoolId).HasColumnName("schoolId");

        entity.HasOne(d => d.School)
                  .WithMany(p => p.Branches)
                  .HasForeignKey(d => d.SchoolId)
                  .HasConstraintName("FK_branches_schools");
      });

      modelBuilder.Entity<ClassStudent>(entity =>
      {
        entity.HasKey(e => e.ClassStudentId);

        entity.ToTable("classesStudents");

        entity.Property(e => e.ClassStudentId)
                  .HasColumnName("classStudentId")
                  .ValueGeneratedNever();

        entity.Property(e => e.ClassroomId).HasColumnName("classroomId");

        entity.Property(e => e.EndDate)
                  .HasColumnName("endDate")
                  .HasColumnType("date");

        entity.Property(e => e.StartDate)
                  .HasColumnName("startDate")
                  .HasColumnType("date");

        entity.Property(e => e.StudentId)
                  .IsRequired()
                  .HasColumnName("studentId")
                  .HasColumnType("char(10)");

        entity.Property(e => e.YearId).HasColumnName("yearId");

        entity.HasOne(d => d.Classroom)
                  .WithMany(p => p.ClassesStudents)
                  .HasForeignKey(d => d.ClassroomId)
                  .HasConstraintName("FK_classesStudents_classrooms");

        entity.HasOne(d => d.Student)
                  .WithMany(p => p.ClassesStudents)
                  .HasForeignKey(d => d.StudentId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_classesStudents_students");

        entity.HasOne(d => d.Year)
                  .WithMany(p => p.ClassesStudents)
                  .HasForeignKey(d => d.YearId)
                  .HasConstraintName("FK_classesStudents_academicYears");
      });

      modelBuilder.Entity<Classrooms>(entity =>
      {
        entity.HasKey(e => e.ClassroomId);

        entity.ToTable("classrooms");

        entity.Property(e => e.ClassroomId)
                  .HasColumnName("classroomId")
                  .ValueGeneratedNever();

        entity.Property(e => e.ClassNameAr)
                  .HasColumnName("classNameAr")
                  .HasMaxLength(25);

        entity.Property(e => e.ClassNameEn)
                  .HasColumnName("classNameEn")
                  .HasMaxLength(25);

        entity.Property(e => e.GradeId).HasColumnName("gradeId");

        entity.HasOne(d => d.Grade)
                  .WithMany(p => p.Classrooms)
                  .HasForeignKey(d => d.GradeId)
                  .HasConstraintName("FK_classrooms_grades");
      });

      modelBuilder.Entity<Department>(entity =>
      {
        entity.HasKey(e => e.DepartmentId);

        entity.ToTable("departments");

        entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

        entity.Property(e => e.DepartmentNameAr)
                  .HasColumnName("departmentNameAr")
                  .HasMaxLength(100);

        entity.Property(e => e.DepartmentNameEn)
                  .HasColumnName("departmentNameEn")
                  .HasMaxLength(100);
      });

      modelBuilder.Entity<DocType>(entity =>
      {
        entity.HasKey(e => e.DocTypeId);

        entity.ToTable("docTypes");

        entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

        entity.Property(e => e.DocTypeAr)
                  .HasColumnName("docTypeAr")
                  .HasMaxLength(50);

        entity.Property(e => e.DocTypeEn)
                  .HasColumnName("docTypeEn")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<Employee>(entity =>
      {
        entity.HasKey(e => e.EmpId);

        entity.ToTable("employees");

        entity.Property(e => e.EmpId)
                  .HasColumnName("empId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        entity.Property(e => e.AddressHome).HasColumnName("addressHome");

        entity.Property(e => e.AddressKsa).HasColumnName("addressKsa");

        entity.Property(e => e.BirthDateG)
                  .HasColumnName("birthDateG")
                  .HasColumnType("date");

        entity.Property(e => e.BirthDateH)
                  .HasColumnName("birthDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.BirthPlace)
                  .HasColumnName("birthPlace")
                  .HasMaxLength(50);

        entity.Property(e => e.CertificateDate)
                  .HasColumnName("certificateDate")
                  .HasColumnType("nchar(7)");

        entity.Property(e => e.CertificateDegree).HasColumnName("certificateDegree");

        entity.Property(e => e.CertificateGrade).HasColumnName("certificateGrade");

        entity.Property(e => e.CertificateMajor)
                  .HasColumnName("certificateMajor")
                  .HasMaxLength(50);

        entity.Property(e => e.CertificateName).HasColumnName("certificateName");

        entity.Property(e => e.CountryId).HasColumnName("countryId");

        entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .HasMaxLength(50);

        entity.Property(e => e.FName)
                  .HasColumnName("fName")
                  .HasMaxLength(20);

        entity.Property(e => e.GName)
                  .HasColumnName("gName")
                  .HasMaxLength(20);

        entity.Property(e => e.Gender).HasColumnName("gender");

        entity.Property(e => e.HasDrivingLicense).HasColumnName("hasDrivingLicense");

        entity.Property(e => e.IdExpireDateG).HasColumnType("date");

        entity.Property(e => e.IdExpireDateH)
                  .HasColumnName("idExpireDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.IdIssuePlace).HasMaxLength(50);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.Property(e => e.IsHandicapped).HasColumnName("isHandicapped");

        entity.Property(e => e.LName)
                  .HasColumnName("lName")
                  .HasMaxLength(20);

        entity.Property(e => e.MName)
                  .HasColumnName("mName")
                  .HasMaxLength(20);

        entity.Property(e => e.MaritalStatus)
                  .HasColumnName("maritalStatus")
                  .HasMaxLength(10);

        entity.Property(e => e.Mobile)
                  .HasColumnName("mobile")
                  .HasMaxLength(15);

        entity.Property(e => e.Mobile2)
                  .HasColumnName("mobile2")
                  .HasMaxLength(15);

        entity.Property(e => e.PasspoerExpireDateG)
                  .HasColumnName("passpoerExpireDateG")
                  .HasColumnType("date");

        entity.Property(e => e.PasspoerExpireDateH)
                  .HasColumnName("passpoerExpireDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.PassportNum)
                  .HasColumnName("passportNum")
                  .HasMaxLength(15);

        entity.Property(e => e.Phone)
                  .HasColumnName("phone")
                  .HasMaxLength(15);

        entity.Property(e => e.PoBox)
                  .HasColumnName("poBox")
                  .HasMaxLength(10);

        entity.Property(e => e.PoCode)
                  .HasColumnName("poCode")
                  .HasMaxLength(10);

        entity.Property(e => e.RelativeAddress).HasColumnName("relativeAddress");

        entity.Property(e => e.RelativeMobile)
                  .HasColumnName("relativeMobile")
                  .HasMaxLength(15);

        entity.Property(e => e.RelativeName)
                  .HasColumnName("relativeName")
                  .HasMaxLength(60);

        entity.Property(e => e.RelativePhone)
                  .HasColumnName("relativePhone")
                  .HasMaxLength(15);

        entity.Property(e => e.Religion)
                  .HasColumnName("religion")
                  .HasMaxLength(15);

        entity.Property(e => e.SpecialNeeds).HasColumnName("specialNeeds");

        entity.HasOne(e => e.Emp)
                  .WithOne(u => u._Employee)
                  .HasForeignKey<Employee>(e => e.EmpId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employees_users");

        entity.HasOne(e => e.Country)
                  .WithMany(c => c.Employees)
                  .HasForeignKey(e => e.CountryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employees_countries");
      });

      modelBuilder.Entity<EmployeeAction>(entity =>
      {
        entity.HasKey(e => new { e.EmpJobId, e.ActionId });

        entity.ToTable("employeesActions");

        entity.Property(e => e.EmpJobId).HasColumnName("empJobId");

        entity.Property(e => e.ActionId).HasColumnName("actionId");

        entity.HasOne(d => d.Action)
                  .WithMany(p => p.EmployeesActions)
                  .HasForeignKey(d => d.ActionId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employeesActions_actions");

        entity.HasOne(d => d.EmpJob)
                  .WithMany(p => p.EmployeesActions)
                  .HasForeignKey(d => d.EmpJobId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employeesActions_employeesJobs");
      });

      modelBuilder.Entity<EmployeeFinance>(entity =>
      {
        entity.HasKey(e => e.EmpId);

        entity.ToTable("employeesFinance");

        entity.Property(e => e.EmpId)
                  .HasColumnName("empId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        entity.Property(e => e.BankAccount)
                  .HasColumnName("bankAccount")
                  .HasMaxLength(50);

        entity.Property(e => e.BankIban)
                  .HasColumnName("bankIban")
                  .HasMaxLength(50);

        entity.Property(e => e.BankName)
                  .HasColumnName("bankName")
                  .HasMaxLength(50);

        entity.Property(e => e.BasicSalary)
                  .HasColumnName("basicSalary")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.Debts)
                  .HasColumnName("debts")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.ExperienceAllowance)
                  .HasColumnName("experienceAllowance")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.HousingAllowance)
                  .HasColumnName("housingAllowance")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.Loans)
                  .HasColumnName("loans")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.OtherAllowance)
                  .HasColumnName("otherAllowance")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.TotalSalary)
                  .HasColumnName("totalSalary")
                  .HasColumnType("smallmoney");

        entity.Property(e => e.TransportAllowance)
                  .HasColumnName("transportAllowance")
                  .HasColumnType("smallmoney");

        entity.HasOne(d => d.Emp)
                  .WithOne(p => p.EmployeesFinance)
                  .HasForeignKey<EmployeeFinance>(d => d.EmpId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employeesFinance_employees");
      });

      modelBuilder.Entity<EmployeeHr>(entity =>
      {
        entity.HasKey(e => e.EmpId);

        entity.ToTable("employeesHR");

        entity.Property(e => e.EmpId)
                  .HasColumnName("empId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        entity.Property(e => e.CeoApproval)
                  .HasColumnName("ceoApproval")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.ContractType)
                  .HasColumnName("contractType")
                  .HasMaxLength(15);

        entity.Property(e => e.HrNotes).HasColumnName("hrNotes");

        entity.Property(e => e.JobInId)
                  .HasColumnName("jobInId")
                  .HasMaxLength(50);

        entity.Property(e => e.NoorRegistered).HasColumnName("noorRegistered");

        entity.Property(e => e.SalahiaDateG).HasColumnType("date");

        entity.Property(e => e.SalahiaDateH).HasColumnType("nchar(10)");

        entity.Property(e => e.SocialSecurityNum).HasColumnName("socialSecurityNum");

        entity.Property(e => e.SocialSecuritySubscription).HasColumnName("socialSecuritySubscription");

        entity.Property(e => e.WorkStartDateH)
                  .HasColumnName("workStartDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.WorkStatus).HasColumnName("workStatus");

        entity.Property(e => e.WrokStartDateG)
                  .HasColumnName("wrokStartDateG")
                  .HasColumnType("date");

        entity.HasOne(d => d.Emp)
                  .WithOne(p => p.EmployeesHr)
                  .HasForeignKey<EmployeeHr>(d => d.EmpId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_EmployeesHR_employees");
      });

      modelBuilder.Entity<EmployeeJob>(entity =>
      {
        entity.HasKey(e => e.EmpJobId);

        entity.ToTable("employeesJobs");

        entity.Property(e => e.EmpJobId)
                  .HasColumnName("empJobId")
                  .ValueGeneratedNever();

        entity.Property(e => e.BranchId).HasColumnName("branchId");

        entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

        entity.Property(e => e.EmpId)
                  .IsRequired()
                  .HasColumnName("empId")
                  .HasColumnType("char(10)");

        entity.Property(e => e.EndDate)
                  .HasColumnName("endDate")
                  .HasColumnType("date");

        entity.Property(e => e.JobId).HasColumnName("jobId");

        entity.Property(e => e.StartDate)
                  .HasColumnName("startDate")
                  .HasColumnType("date");

        entity.HasOne(d => d.Department)
                  .WithMany(p => p.EmployeesJobs)
                  .HasForeignKey(d => d.DepartmentId)
                  .HasConstraintName("FK_employeesJobs_departments");

        entity.HasOne(d => d.Emp)
                  .WithMany(p => p.EmployeesJobs)
                  .HasForeignKey(d => d.EmpId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employeesJobs_employees");

        entity.HasOne(d => d.Job)
                  .WithMany(p => p.EmployeesJobs)
                  .HasForeignKey(d => d.JobId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_employeesJobs_jobs");
      });

      modelBuilder.Entity<Grade>(entity =>
      {
        entity.HasKey(e => e.GradeId);

        entity.ToTable("grades");

        entity.Property(e => e.GradeId).HasColumnName("gradeId");

        entity.Property(e => e.GradeNameAr)
                  .HasColumnName("gradeNameAr")
                  .HasMaxLength(25);

        entity.Property(e => e.GradeNameEn)
                  .HasColumnName("gradeNameEn")
                  .HasMaxLength(25);

        entity.Property(e => e.StageId).HasColumnName("stageId");

        entity.HasOne(d => d.Stage)
                  .WithMany(p => p.Grades)
                  .HasForeignKey(d => d.StageId)
                  .HasConstraintName("FK_grades_stages");
      });

      modelBuilder.Entity<GradesSubjects>(entity =>
      {
        entity.HasKey(e => e.GradeSubjectId);

        entity.ToTable("gradesSubjects");

        entity.HasIndex(e => new { e.GradeId, e.SubjectId })
                  .HasName("ucGradeSubject")
                  .IsUnique();

        entity.Property(e => e.GradeSubjectId)
                  .HasColumnName("gradeSubjectId")
                  .ValueGeneratedNever();

        entity.Property(e => e.GradeId).HasColumnName("gradeId");

        entity.Property(e => e.PeriodsCount).HasColumnName("periodsCount");

        entity.Property(e => e.SubjectId).HasColumnName("subjectId");

        entity.HasOne(d => d.Grade)
                  .WithMany(p => p.GradesSubjects)
                  .HasForeignKey(d => d.GradeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_gradesSubjects_grades");

        entity.HasOne(d => d.Subject)
                  .WithMany(p => p.GradesSubjects)
                  .HasForeignKey(d => d.SubjectId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_gradesSubjects_subjects");
      });

      modelBuilder.Entity<Job>(entity =>
      {
        entity.HasKey(e => e.JobId);

        entity.ToTable("jobs");

        entity.Property(e => e.JobId)
                  .HasColumnName("jobId")
                  .ValueGeneratedNever();

        entity.Property(e => e.JobDescription).HasColumnName("jobDescription");

        entity.Property(e => e.JobNameAr)
                  .HasColumnName("jobNameAr")
                  .HasMaxLength(100);

        entity.Property(e => e.JobNameEn)
                  .HasColumnName("jobNameEn")
                  .HasMaxLength(100);
      });

      modelBuilder.Entity<Country>(entity =>
      {
        entity.HasKey(e => e.CountryId);

        entity.ToTable("countries");

        entity.Property(e => e.CountryId)
                  .HasColumnName("countryId")
                  .ValueGeneratedNever();

        entity.Property(e => e.CountryAr)
                  .HasColumnName("countryAr")
                  .HasMaxLength(50);

        entity.Property(e => e.CountryEn)
                  .HasColumnName("countryEn")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<JobAction>(entity =>
      {
        entity.HasKey(e => new { e.JobId, e.ActionId });

        entity.ToTable("jobsActions");

        entity.Property(e => e.JobId).HasColumnName("jobId");

        entity.Property(e => e.ActionId).HasColumnName("actionId");

        entity.HasOne(d => d.Action)
                  .WithMany(p => p.JobsActions)
                  .HasForeignKey(d => d.ActionId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_jobsActions_actions");

        entity.HasOne(d => d.Job)
                  .WithMany(p => p.JobsActions)
                  .HasForeignKey(d => d.JobId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_jobsActions_jobs");
      });

      modelBuilder.Entity<Lesson>(entity =>
      {
        entity.HasKey(e => e.LessonId);

        entity.ToTable("lessons");

        entity.Property(e => e.LessonId)
                  .HasColumnName("lessonId")
                  .ValueGeneratedNever();

        entity.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

        entity.Property(e => e.LessonObjectives).HasColumnName("lessonObjectives");

        entity.Property(e => e.LessonTitle)
                  .HasColumnName("lessonTitle")
                  .HasMaxLength(150);

        entity.Property(e => e.SemesterId).HasColumnName("semesterId");
      });

      modelBuilder.Entity<LessonFile>(entity =>
      {
        entity.HasKey(e => e.LessonFileId);

        entity.ToTable("lessonsFiles");

        entity.Property(e => e.LessonFileId)
                  .HasColumnName("lessonFileId")
                  .ValueGeneratedNever();

        entity.Property(e => e.CreatedAt)
                  .HasColumnName("createdAt")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

        entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

        entity.Property(e => e.FilePath).HasColumnName("filePath");

        entity.Property(e => e.IsExternalLink).HasColumnName("isExternalLink");

        entity.Property(e => e.LessonId).HasColumnName("lessonId");

        entity.HasOne(d => d.DocType)
                  .WithMany(p => p.LessonsFiles)
                  .HasForeignKey(d => d.DocTypeId)
                  .HasConstraintName("FK_lessonsFiles_docTypes");

        entity.HasOne(d => d.Lesson)
                  .WithMany(p => p.LessonsFiles)
                  .HasForeignKey(d => d.LessonId)
                  .HasConstraintName("FK_lessonsFiles_lessons");
      });

      modelBuilder.Entity<Major>(entity =>
      {
        entity.HasKey(e => e.MajorId);

        entity.ToTable("majors");

        entity.Property(e => e.MajorId).HasColumnName("majorId");

        entity.Property(e => e.MajorNameAr)
                  .HasColumnName("majorNameAr")
                  .HasMaxLength(50);

        entity.Property(e => e.MajorNameEn)
                  .HasColumnName("majorNameEn")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<Parent>(entity =>
      {
        entity.HasKey(e => e.ParentId);

        entity.ToTable("parents");

        entity.Property(e => e.ParentId)
                  .HasColumnName("parentId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        entity.Property(e => e.CityId).HasColumnName("cityId");

        entity.Property(e => e.District).HasColumnName("district");

        entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .HasMaxLength(50);

        entity.Property(e => e.FName)
                  .HasColumnName("fName")
                  .HasMaxLength(20);

        entity.Property(e => e.GName)
                  .HasColumnName("gName")
                  .HasMaxLength(20);

        entity.Property(e => e.HouseNum)
                  .HasColumnName("houseNum")
                  .HasMaxLength(5);

        entity.Property(e => e.IdExpireDateG).HasColumnType("date");

        entity.Property(e => e.IdExpireDateH)
                  .HasColumnName("idExpireDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.IdIssuePlace).HasMaxLength(50);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.Property(e => e.Job).HasColumnName("job");

        entity.Property(e => e.LName)
                  .HasColumnName("lName")
                  .HasMaxLength(20);

        entity.Property(e => e.MName)
                  .HasColumnName("mName")
                  .HasMaxLength(20);

        entity.Property(e => e.Mobile1)
                  .HasColumnName("mobile1")
                  .HasMaxLength(15);

        entity.Property(e => e.Mobile2)
                  .HasColumnName("mobile2")
                  .HasMaxLength(15);

        entity.Property(e => e.CountryId)
                  .HasColumnName("countryId")
                  .HasMaxLength(15);

        entity.Property(e => e.Phone)
                  .HasColumnName("phone")
                  .HasMaxLength(15);

        entity.Property(e => e.RelativeAddress).HasColumnName("relativeAddress");

        entity.Property(e => e.RelativeMobile)
                  .HasColumnName("relativeMobile")
                  .HasMaxLength(15);

        entity.Property(e => e.RelativeName)
                  .HasColumnName("relativeName")
                  .HasMaxLength(60);

        entity.Property(e => e.RelativePhone)
                  .HasColumnName("relativePhone")
                  .HasMaxLength(15);

        entity.Property(e => e.RelativeRelation)
                  .HasColumnName("relativeRelation")
                  .HasMaxLength(50);

        entity.Property(e => e.Street).HasColumnName("street");

        entity.Property(e => e.WorkAddress).HasColumnName("workAddress");

        entity.Property(e => e.WorkPhone)
                  .HasColumnName("workPhone")
                  .HasMaxLength(15);

        entity.HasOne(p => p._Parent)
                  .WithOne(u => u._Parent)
                  .HasForeignKey<Parent>(p => p.ParentId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_parents_users");

        entity.HasOne(p => p.Country)
                  .WithMany(c => c.Parents)
                  .HasForeignKey(p => p.CountryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_parents_countries");
      });

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

        entity.Property(e => e.SchoolName)
                  .HasColumnName("schoolName")
                  .HasMaxLength(150);

        entity.Property(e => e.SchoolNameEn)
                  .HasColumnName("schoolNameEn")
                  .HasMaxLength(150);

        entity.Property(e => e.StartDate)
                  .HasColumnName("startDate")
                  .HasColumnType("date");
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

        entity.Property(e => e.FName)
                  .HasColumnName("fName")
                  .HasMaxLength(20);

        entity.Property(e => e.GName)
                  .HasColumnName("gName")
                  .HasMaxLength(20);

        entity.Property(e => e.Gender).HasColumnName("gender");

        entity.Property(e => e.IdExpireDateG).HasColumnType("date");

        entity.Property(e => e.IdExpireDateH)
                  .HasColumnName("idExpireDateH")
                  .HasColumnType("nchar(10)");

        entity.Property(e => e.IdIssuePlace).HasMaxLength(50);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.Property(e => e.LName)
                  .HasColumnName("lName")
                  .HasMaxLength(20);

        entity.Property(e => e.MName)
                  .HasColumnName("mName")
                  .HasMaxLength(20);

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

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.UserId);

        entity.ToTable("users");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        entity.Property(e => e.AccountStatusId).HasColumnName("accountStatusId");

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.Property(e => e.LastLogin)
                  .HasColumnName("lastLogin")
                  .HasColumnType("datetime");

        entity.Property(e => e.SubscribeDate)
                  .HasColumnName("subscribeDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.PasswordHash)
                  .HasColumnName("passwordHash")
                  .HasMaxLength(50);

        entity.Property(e => e.PasswordSalt)
                  .HasColumnName("passwordSalt")
                  .HasMaxLength(50);

        entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

        entity.HasOne(d => d.UserType)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.UserTypeId)
                  .HasConstraintName("FK_users_userTypes");
      });

      modelBuilder.Entity<UsersDocs>(entity =>
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
    }
  }
}
