using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class HealthIssueConfig : IEntityTypeConfiguration<HealthIssue>
  {
    public void Configure(EntityTypeBuilder<HealthIssue> builder)
    {
      builder.HasKey(e => e.HealthIssueId);

      builder.ToTable("healthIssues");

      builder.Property(e => e.HealthIssueId).HasColumnName("healthIssueId");
      builder.Property(e => e.HealthIssueNameAr).HasColumnName("healthIssueNameAr").HasMaxLength(100);
      builder.Property(e => e.HealthIssueNameEn).HasColumnName("healthIssueNameEn").HasMaxLength(100);
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}