using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class PeriodFileConfig : IEntityTypeConfiguration<PeriodFile>
  {
    public void Configure(EntityTypeBuilder<PeriodFile> builder)
    {
      builder.HasKey(e => e.PeriodFileId);

      builder.ToTable("periodsFiles");

      builder.Property(e => e.PeriodFileId)
                .HasColumnName("periodFileId")
                .ValueGeneratedNever();

      builder.Property(e => e.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("smalldatetime");

      builder.Property(e => e.CreatedBy).HasColumnName("createdBy");

      builder.Property(e => e.DocTypeId).HasColumnName("docTypeId");

      builder.Property(e => e.FilePath).HasColumnName("filePath");

      builder.Property(e => e.IsExternalLink).HasColumnName("isExternalLink");

      builder.Property(e => e.WeekPlanId).HasColumnName("weekPlanId");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.PeriodsFiles)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_periodsFiles");

      builder.HasOne(d => d.DocType)
                .WithMany(p => p.PeriodsFiles)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK_periodsFiles_docTypes");

      builder.HasOne(d => d.WeekPlan)
                .WithMany(p => p.PeriodsFiles)
                .HasForeignKey(d => d.WeekPlanId)
                .HasConstraintName("FK_periodsFiles_weeksPlans");
    }
  }
}