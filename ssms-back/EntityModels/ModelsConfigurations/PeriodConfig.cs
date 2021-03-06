using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class PeriodConfig : IEntityTypeConfiguration<Period>
  {
    public void Configure(EntityTypeBuilder<Period> builder)
    {
      builder.HasKey(e => e.PeriodId);

      builder.ToTable("periods");

      builder.Property(e => e.PeriodId)
                .HasColumnName("periodId")
                .ValueGeneratedNever();

      builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.EndTime).HasColumnName("endTime");

      builder.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

      builder.Property(e => e.PeriodDate).HasColumnName("periodDate").HasColumnType("date");

      builder.Property(e => e.SchoolDayEventId).HasColumnName("schoolDayEventId");

      builder.Property(e => e.SemesterId).HasColumnName("semesterId");

      builder.Property(e => e.StartTime).HasColumnName("startTime");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.Periods)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_periods");

      builder.HasOne(d => d._Classroom)
                .WithMany(p => p.Periods)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_periods_classrooms");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.Periods)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_periods_employeesJobs");

      builder.HasOne(d => d.GradeSubject)
                .WithMany(p => p.Periods)
                .HasForeignKey(d => d.GradeSubjectId)
                .HasConstraintName("FK_periods_gradesSubjects");

      builder.HasOne(d => d.SchoolDayEvent)
                .WithMany(p => p.Periods)
                .HasForeignKey(d => d.SchoolDayEventId)
                .HasConstraintName("FK_periods_schoolDayEvents");

      builder.HasOne(d => d.Semester)
                .WithMany(p => p.Periods)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_periods_academicSemesters");

    }
  }
}