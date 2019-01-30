using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ActionConfig : IEntityTypeConfiguration<Action>
  {
    public void Configure(EntityTypeBuilder<Action> builder)
    {
      builder.HasKey(e => e.ActionId);

      builder.ToTable("actions");

      builder.Property(e => e.ActionId)
                .HasColumnName("actionId")
                .ValueGeneratedNever();

      builder.Property(e => e.ActionNameAr)
                .HasColumnName("actionNameAr")
                .HasMaxLength(100);

      builder.Property(e => e.ActionNameEn)
                .HasColumnName("actionNameEn")
                .HasMaxLength(100);

      builder.Property(e => e.ActionUrl)
                .HasColumnName("actionUrl")
                .HasMaxLength(100);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}