using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class CityConfig : IEntityTypeConfiguration<City>
  {
    public void Configure(EntityTypeBuilder<City> builder)
    {
      builder.HasKey(e => e.CityId);

      builder.ToTable("cities");

      builder.Property(e => e.CityId).HasColumnName("cityId");
      builder.Property(e => e.CityNameAr).HasColumnName("cityNameAr").HasMaxLength(100).IsRequired();
      builder.Property(e => e.CityNameEn).HasColumnName("cityNameEn").HasMaxLength(100).IsRequired();
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}