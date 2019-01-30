using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class AcademicWeekConfig : IEntityTypeConfiguration<AcademicWeek>
  {
    public void Configure(EntityTypeBuilder<AcademicWeek> builder)
    {
      builder.HasKey(e => e.WeekId);

      builder.ToTable("academicWeeks");

      builder.Property(e => e.WeekId)
                .HasColumnName("weekId")
                .ValueGeneratedNever();

      builder.Property(e => e.SemesterId).HasColumnName("semesterId");

      builder.Property(e => e.WeekEndDateG).HasColumnType("date");

      builder.Property(e => e.WeekEndDateH).HasColumnType("nchar(10)");

      builder.Property(e => e.WeekNameAr)
                .HasColumnName("weekNameAr")
                .HasMaxLength(25);

      builder.Property(e => e.WeekNameEn)
                .HasColumnName("weekNameEn")
                .HasMaxLength(25);

      builder.Property(e => e.WeekStartDateG)
                .HasColumnName("weekStartDateG")
                .HasColumnType("date");

      builder.Property(e => e.WeekStartDateH)
                .HasColumnName("weekStartDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Semester)
                .WithMany(p => p.AcademicWeeks)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_academicWeeks_academicSemesters");
    }
  }
}