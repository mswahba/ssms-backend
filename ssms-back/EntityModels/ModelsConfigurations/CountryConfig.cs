using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class CountryConfig : IEntityTypeConfiguration<Country>
  {
    public void Configure(EntityTypeBuilder<Country> builder)
    {
      builder.HasKey(e => e.CountryId);

      builder.ToTable("countries");

      builder.Property(e => e.CountryId)
                .HasColumnName("countryId")
                .ValueGeneratedNever();

      builder.Property(e => e.CountryAr)
                .HasColumnName("countryAr")
                .HasMaxLength(50);

      builder.Property(e => e.CountryEn)
                .HasColumnName("countryEn")
                .HasMaxLength(50);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}