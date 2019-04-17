using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class MediaCategoryConfig : IEntityTypeConfiguration<MediaCategory>
  {
    public void Configure(EntityTypeBuilder<MediaCategory> builder)
    {
      builder.HasKey(e => e.CategoryId);

      builder.ToTable("mediaCategories");

      builder.Property(e => e.CategoryId).HasColumnName("categoryId");
      builder.Property(e => e.CategoryNameAr).HasColumnName("categoryNameAr").HasMaxLength(100);
      builder.Property(e => e.CategoryNameEn).HasColumnName("categoryNameEn").HasMaxLength(100);
      builder.Property(e => e.CategoryType).HasColumnName("categoryType").HasMaxLength(100);
    }
  }
}