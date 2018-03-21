using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SSMS.EntityModels
{
    public partial class SSMSContext : DbContext
    {
        public virtual DbSet<AcademicSemester> AcademicSemesters { get; set; }
        public virtual DbSet<AcademicWeek> AcademicWeeks { get; set; }
        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeFinance> EmployeesFinance { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradeSubject> GradeSubjects { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentEdu> StudentsEdu { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDocs> UsersDocs { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8GK916E;Database=SSMS;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicSemester>(entity =>
            {
                entity.HasKey(e => e.SemesterId);

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

                entity.Property(e => e.YearId).HasColumnName("yearId");
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

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => e.ClassroomId);

                entity.ToTable("classrooms");

                entity.Property(e => e.ClassroomId).HasColumnName("classroomId");

                entity.Property(e => e.ClassNameAr)
                    .HasColumnName("classNameAr")
                    .HasMaxLength(25);

                entity.Property(e => e.ClassNameEn)
                    .HasColumnName("classNameEn")
                    .HasMaxLength(25);

                entity.Property(e => e.GradeId).HasColumnName("gradeId");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.StageId).HasColumnName("stageId");
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
                entity.HasKey(e => e.EmptId);

                entity.ToTable("employees");

                entity.Property(e => e.EmptId)
                    .HasColumnName("emptId")
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

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

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
            });

            modelBuilder.Entity<GradeSubject>(entity =>
            {
                entity.HasKey(e => new { e.GradeId, e.SubjectId });

                entity.ToTable("gradeSubjects");

                entity.Property(e => e.GradeId).HasColumnName("gradeId");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.PeriodNumber).HasColumnName("periodNumber");
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

                entity.Property(e => e.MobileMother)
                    .HasColumnName("mobileMother")
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
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");                    
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

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.SectionId);

                entity.ToTable("sections");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.SectionNameAr)
                    .HasColumnName("sectionNameAr")
                    .HasMaxLength(8);

                entity.Property(e => e.SectionNameEn)
                    .HasColumnName("sectionNameEn")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.HasKey(e => e.StageId);

                entity.ToTable("stages");

                entity.Property(e => e.StageId).HasColumnName("stageId");

                entity.Property(e => e.StageNameAr)
                    .HasColumnName("stageNameAr")
                    .HasMaxLength(25);

                entity.Property(e => e.StageNameEn)
                    .HasColumnName("stageNameEn")
                    .HasMaxLength(25);
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

                entity.Property(e => e.LName)
                    .HasColumnName("lName")
                    .HasMaxLength(20);

                entity.Property(e => e.MName)
                    .HasColumnName("mName")
                    .HasMaxLength(20);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(15);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentId")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SpecialNeeds).HasColumnName("specialNeeds");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<StudentEdu>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("studentsEdu");

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.GradeId).HasColumnName("gradeId");

                entity.Property(e => e.PreviousSchool)
                    .HasColumnName("previousSchool")
                    .HasMaxLength(50);

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.StageId).HasColumnName("stageId");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("subjects");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.MajorId).HasColumnName("majorId");

                entity.Property(e => e.SubjectNameAr)
                    .HasColumnName("subjectNameAr")
                    .HasMaxLength(25);

                entity.Property(e => e.SubjectNameEn)
                    .HasColumnName("subjectNameEn")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("lastLogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscribeDate)
                    .HasColumnName("subscribeDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(25);

                entity.Property(e => e.UserType).HasColumnName("userType");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");                
            });

            modelBuilder.Entity<UserDocs>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DocTypeId });

                entity.ToTable("usersDocs");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

                entity.Property(e => e.FilePath)
                    .HasColumnName("filePath")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("userTypes");

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.Property(e => e.UserTypeName)
                    .HasColumnName("userType")
                    .HasMaxLength(25);
            });
        }
    }
}
