using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class RelationConfig : IEntityTypeConfiguration<Relation>
  {
    public void Configure(EntityTypeBuilder<Relation> builder)
    {
      builder.HasKey(e => e.RelationId);

      builder.ToTable("relations");

      builder.Property(e => e.RelationId).HasColumnName("relationId");
      builder.Property(e => e.RelationNameAr).HasColumnName("relationNameAr");
      builder.Property(e => e.RelationNameEn).HasColumnName("relationNameEn");
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}