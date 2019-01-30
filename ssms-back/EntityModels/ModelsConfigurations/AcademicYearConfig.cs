using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class AcademicYearConfig : IEntityTypeConfiguration<AcademicYear>
  {
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
      builder.HasKey(e => e.YearId);

      builder.ToTable("academicYears");

      builder.Property(e => e.YearId).HasColumnName("yearId");

      builder.Property(e => e.YearEndDateG)
                .HasColumnName("yearEndDateG")
                .HasColumnType("date");

      builder.Property(e => e.YearEndDateH)
                .HasColumnName("yearEndDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.YearNameG)
                .HasColumnName("yearNameG")
                .HasMaxLength(10);

      builder.Property(e => e.YearNameH)
                .HasColumnName("yearNameH")
                .HasMaxLength(10);

      builder.Property(e => e.YearStartDateG)
                .HasColumnName("yearStartDateG")
                .HasColumnType("date");

      builder.Property(e => e.YearStartDateH)
                .HasColumnName("yearStartDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}