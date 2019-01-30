using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class RemedialProcedureConfig : IEntityTypeConfiguration<RemedialProcedure>
  {
    public void Configure(EntityTypeBuilder<RemedialProcedure> builder)
    {
      builder.HasKey(e => e.ProcedureId);

      builder.ToTable("remedialProcedures");

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