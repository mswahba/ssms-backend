using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class WeekPlanConfig : IEntityTypeConfiguration<WeekPlan>
  {
    public void Configure(EntityTypeBuilder<WeekPlan> builder)
    {
      builder.HasKey(e => e.WeekPlanId);

      builder.ToTable("weeksPlans");

      builder.Property(e => e.WeekPlanId)
                .HasColumnName("weekPlanId")
                .ValueGeneratedNever();

      builder.Property(e => e.Date).HasColumnName("date").HasColumnType("date");

      builder.Property(e => e.Homework).HasColumnName("homework");

      builder.Property(e => e.LessonId).HasColumnName("lessonId");

      builder.Property(e => e.Quiz).HasColumnName("quiz");

      builder.Property(e => e.TimeTableId).HasColumnName("timeTableId");

      builder.Property(e => e.WeekId).HasColumnName("weekId");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.WeeksPlans)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_weeksPlans");

      builder.HasOne(d => d.Lesson)
                .WithMany(p => p.WeeksPlans)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK_weeksPlans_lessons");

      builder.HasOne(d => d.TimeTable)
                .WithMany(p => p.WeeksPlans)
                .HasForeignKey(d => d.TimeTableId)
                .HasConstraintName("FK_weeksPlans_timeTable");

      builder.HasOne(d => d.Week)
                .WithMany(p => p.WeeksPlans)
                .HasForeignKey(d => d.WeekId)
                .HasConstraintName("FK_weeksPlans_academicWeeks");

    }
  }
}