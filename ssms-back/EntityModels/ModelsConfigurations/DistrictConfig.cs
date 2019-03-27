using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class DistrictConfig : IEntityTypeConfiguration<District>
  {
    public void Configure(EntityTypeBuilder<District> builder)
    {
      builder.HasKey(e => e.DistrictId);

      builder.ToTable("districts");

      builder.Property(e => e.DistrictId).HasColumnName("districtId");
      builder.Property(e => e.DistrictNameAr).HasColumnName("districtNameAr").HasMaxLength(100).IsRequired();
      builder.Property(e => e.DistrictNameEn).HasColumnName("districtNameEn").HasMaxLength(100).IsRequired();
      builder.Property(e => e.CityId).HasColumnName("cityId");
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._City)
        .WithMany(c => c.Districts)
        .HasForeignKey(e => e.CityId)
        .HasConstraintName("FK_cities_districts");
    }
  }
}