using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class RelativeConfig : IEntityTypeConfiguration<Relative>
  {
    public void Configure(EntityTypeBuilder<Relative> builder)
    {
      builder.HasKey(e => e.RelativeId);

      builder.ToTable("relatives");

      builder.Property(e => e.RelativeId).HasColumnName("relativeId");
      builder.Property(e => e.RelativeNameAr).HasColumnName("relativeNameAr").HasMaxLength(50).IsRequired();
      builder.Property(e => e.RelativeNameEn).HasColumnName("relativeNameEn").HasMaxLength(50).IsRequired();
      builder.Property(e => e.Mobile1).HasColumnName("mobile1").HasMaxLength(15).IsRequired();
      builder.Property(e => e.Mobile2).HasColumnName("mobile2").HasMaxLength(15);
      builder.Property(e => e.Phone).HasColumnName("phone").HasMaxLength(15);
      builder.Property(e => e.Address).HasColumnName("address");
      builder.Property(e => e.ParentId).HasColumnName("parentId").HasMaxLength(10);
      builder.Property(e => e.CreatedAt).HasColumnName("createdAt");
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._Parent)
            .WithMany(p => p.Relatives)
            .HasForeignKey(e => e.ParentId)
            .HasConstraintName("FK_parents_relatives");
    }
  }
}