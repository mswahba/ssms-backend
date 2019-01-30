using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class JobActionConfig : IEntityTypeConfiguration<JobAction>
  {
    public void Configure(EntityTypeBuilder<JobAction> builder)
    {
      builder.HasKey(e => new { e.JobId, e.ActionId });

      builder.ToTable("jobsActions");

      builder.Property(e => e.JobId).HasColumnName("jobId");

      builder.Property(e => e.ActionId).HasColumnName("actionId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Action)
                .WithMany(p => p.JobsActions)
                .HasForeignKey(d => d.ActionId)
                .HasConstraintName("FK_jobsActions_actions");

      builder.HasOne(d => d.Job)
                .WithMany(p => p.JobsActions)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_jobsActions_jobs");
    }
  }
}