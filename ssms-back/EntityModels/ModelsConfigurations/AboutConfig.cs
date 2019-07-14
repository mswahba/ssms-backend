using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class AboutConfig : IEntityTypeConfiguration<About>
  {
    public void Configure(EntityTypeBuilder<About> builder)
    {
      builder.HasKey(e => e.AboutId);

      builder.ToTable("abouts");

      builder.Property(e => e.AboutId).HasColumnName("aboutId");

      builder.Property(e => e.AboutTitleAr).HasColumnName("aboutTitleAr").HasMaxLength(100).IsRequired();
      builder.Property(e => e.AboutTitleEn).HasColumnName("aboutTitleEn").HasMaxLength(100).IsRequired();
      builder.Property(e => e.AboutTextAr).HasColumnName("aboutTextAr").IsRequired();
      builder.Property(e => e.AboutTextEn).HasColumnName("aboutTextEn").IsRequired();
      builder.Property(e => e.AboutDate).HasColumnName("aboutDate").HasColumnType("smalldatetime").IsRequired();
      builder.Property(e => e.ForCompany).HasColumnName("forCompany").IsRequired();
      builder.Property(e => e.PhotoURL).HasColumnName("photoURL");
      builder.Property(e => e.VideoURL).HasColumnName("videoURL");

      builder.Property(e => e.SchoolId).HasColumnName("schoolId");
      builder.Property(e => e.StageId).HasColumnName("stageId");
      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");
      builder.Property(e => e.CategoryId).HasColumnName("categoryId");

      builder.HasOne(e => e._School)
            .WithMany(d => d.Abouts)
            .HasForeignKey(e => e.SchoolId)
            .HasConstraintName("FK_schools_abouts");

      builder.HasOne(e => e._Department)
            .WithMany(d => d.Abouts)
            .HasForeignKey(e => e.StageId)
            .HasConstraintName("FK_departments_abouts");

      builder.HasOne(e => e._EmployeeJob)
            .WithMany(d => d.Abouts)
            .HasForeignKey(e => e.EmpJobId)
            .HasConstraintName("FK_employeesJobs_abouts");

      builder.HasOne(e => e._MediaCategory)
            .WithMany(d => d.Abouts)
            .HasForeignKey(e => e.CategoryId)
            .HasConstraintName("FK_mediaCategories_abouts");

    }
  }
}