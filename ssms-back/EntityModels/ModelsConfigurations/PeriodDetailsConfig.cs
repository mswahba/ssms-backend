using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class PeriodDetailsConfig : IEntityTypeConfiguration<PeriodDetails>
  {
    public void Configure(EntityTypeBuilder<PeriodDetails> builder)
    {
      builder.HasKey(e => e.PeriodDetailId);

      builder.ToTable("periodsDetails");

      builder.Property(e => e.PeriodDetailId)
                .HasColumnName("periodDetailId")
                .ValueGeneratedNever();

      builder.Property(e => e.AttandanceTime).HasColumnName("attandanceTime");

      builder.Property(e => e.HomeworkRate).HasColumnName("homeworkRate");

      builder.Property(e => e.IsEalryExit).HasColumnName("isEalryExit");

      builder.Property(e => e.LeaveTime).HasColumnName("leaveTime");

      builder.Property(e => e.Notes).HasColumnName("notes");

      builder.Property(e => e.ParticipationsCount).HasColumnName("participationsCount");

      builder.Property(e => e.ParticipationsQuality).HasColumnName("participationsQuality");

      builder.Property(e => e.PeriodId).HasColumnName("periodId");

      builder.Property(e => e.StudentId)
                .HasColumnName("studentId")
                .HasColumnType("char(10)");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Period)
                .WithMany(p => p.PeriodsDetails)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK_periodsDetails_periods");

      builder.HasOne(d => d.Student)
                .WithMany(p => p.PeriodsDetails)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_periodsDetails_students");

    }
  }
}