using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
  public partial class User
  {
    public User()
    {
      Users = new HashSet<User>();
      Departments = new HashSet<Department>();
      EmployeesActions = new HashSet<EmployeeAction>();
      EmployeesFinances = new HashSet<EmployeeFinance>();
      EmployeesHrs = new HashSet<EmployeeHR>();
      EmployeesJobs = new HashSet<EmployeeJob>();
      Lessons = new HashSet<Lesson>();
      LessonsFiles = new HashSet<LessonFile>();
      Notifications = new HashSet<Notification>();
      NotificationTypesUsers = new HashSet<NotificationTypeUser>();
      Periods = new HashSet<Period>();
      PeriodsDetails = new HashSet<PeriodDetails>();
      PeriodsFiles = new HashSet<PeriodFile>();
      RefreshTokens = new HashSet<RefreshToken>();
      Subjects = new HashSet<Subject>();
      TeachersEdus = new HashSet<TeacherEdu>();
      TeachersQuorums = new HashSet<TeacherQuorum>();
      TimeTables = new HashSet<TimeTable>();
      UsersDocs = new HashSet<UserDoc>();
      VerificationCodes = new HashSet<VerificationCode>();
      WeeksPlans = new HashSet<WeekPlan>();
      SubscribeDate = DateTime.UtcNow.AddHours(3);
      LastActive = DateTime.UtcNow.AddHours(3);
      AccountStatusId = 1;
      IsDeleted = false;
    }

    public string UserId { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public byte? UserTypeId { get; set; }
    public byte? AccountStatusId { get; set; }
    public DateTime? SubscribeDate { get; set; }
    public DateTime? LastActive { get; set; }

    public string IssuerId { get; set; }
    public DateTime SysStartTime { get; set; }
    public DateTime SysEndTime { get; set; }
    public bool? IsDeleted { get; set; }

    public Employee _Employee { get; set; }
    public Parent _Parent { get; set; }
    public Student _Student { get; set; }
    public User _User { get; set; }
    public UserType UserType { get; set; }
    public AccountStatus AccountStatus { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<Department> Departments { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<EmployeeAction> EmployeesActions { get; set; }
    public ICollection<EmployeeFinance> EmployeesFinances { get; set; }
    public ICollection<EmployeeHR> EmployeesHrs { get; set; }
    public ICollection<EmployeeJob> EmployeesJobs { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<LessonFile> LessonsFiles { get; set; }
    public ICollection<Period> Periods { get; set; }
    public ICollection<PeriodDetails> PeriodsDetails { get; set; }
    public ICollection<PeriodFile> PeriodsFiles { get; set; }
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<TeacherEdu> TeachersEdus { get; set; }
    public ICollection<TeacherQuorum> TeachersQuorums { get; set; }
    public ICollection<TimeTable> TimeTables { get; set; }
    public ICollection<UserDoc> UsersDocs { get; set; }
    public ICollection<VerificationCode> VerificationCodes { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<NotificationTypeUser> NotificationTypesUsers { get; set; }
    public ICollection<WeekPlan> WeeksPlans { get; set; }

  }
}
