using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class JobConfig : IEntityTypeConfiguration<Job>
  {
    public void Configure(EntityTypeBuilder<Job> builder)
    {
      builder.HasKey(e => e.JobId);

      builder.ToTable("jobs");

      builder.Property(e => e.JobId)
                .HasColumnName("jobId")
                .ValueGeneratedNever();

      builder.Property(e => e.JobDescription).HasColumnName("jobDescription");

      builder.Property(e => e.JobNameAr)
                .HasColumnName("jobNameAr")
                .HasMaxLength(100);

      builder.Property(e => e.JobNameEn)
                .HasColumnName("jobNameEn")
                .HasMaxLength(100);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}