using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class AcademicSemesterConfig : IEntityTypeConfiguration<AcademicSemester>
  {
    public void Configure(EntityTypeBuilder<AcademicSemester> builder)
    {
      builder.HasKey(e => e.SemesterId);

      builder.ToTable("academicSemesters");

      builder.Property(e => e.SemesterId).HasColumnName("semesterId");

      builder.Property(e => e.SemesterEndDateG)
                .HasColumnName("semesterEndDateG")
                .HasColumnType("date");

      builder.Property(e => e.SemesterEndDateH)
                .HasColumnName("semesterEndDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.SemesterNameAr)
                .HasColumnName("semesterNameAr")
                .HasMaxLength(25);

      builder.Property(e => e.SemesterNameEn)
                .HasColumnName("semesterNameEn")
                .HasMaxLength(25);

      builder.Property(e => e.SemesterStartDateG)
                .HasColumnName("semesterStartDateG")
                .HasColumnType("date");

      builder.Property(e => e.SemesterStartDateH)
                .HasColumnName("semesterStartDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.YearId).HasColumnName("yearId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Year)
                .WithMany(p => p.AcademicSemesters)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_academicSemesters_academicYears");

    }
  }
}