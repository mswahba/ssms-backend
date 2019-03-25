using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ProcedureConfig : IEntityTypeConfiguration<Procedure>
  {
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
      builder.HasKey(e => e.ProcedureId);

      builder.ToTable("procedures");

      builder.Property(e => e.ProcedureId)
                .HasColumnName("procedureId")
                .ValueGeneratedNever();

      builder.Property(e => e.CategoryId).HasColumnName("categoryId");

      builder.Property(e => e.ProcedureNameAr)
                .HasColumnName("procedureNameAr")
                .HasMaxLength(150);

      builder.Property(e => e.ProcedureNameEn)
                .HasColumnName("procedureNameEn")
                .HasMaxLength(150);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}