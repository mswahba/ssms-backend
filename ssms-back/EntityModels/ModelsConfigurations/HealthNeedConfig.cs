using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class HealthNeedConfig : IEntityTypeConfiguration<HealthNeed>
  {
    public void Configure(EntityTypeBuilder<HealthNeed> builder)
    {
      builder.HasKey(e => e.HealthNeedId);

      builder.ToTable("healthNeeds");

      builder.Property(e => e.HealthNeedId).HasColumnName("healthNeedId");
      builder.Property(e => e.HealthNeedNameAr).HasColumnName("healthNeedNameAr").HasMaxLength(100);
      builder.Property(e => e.HealthNeedNameEn).HasColumnName("healthIssueNameEn").HasMaxLength(100);
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}