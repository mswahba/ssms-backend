using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class AlbumConfig : IEntityTypeConfiguration<Album>
  {
    public void Configure(EntityTypeBuilder<Album> builder)
    {
      builder.HasKey(e => e.AlbumId);

      builder.ToTable("albums");

      builder.Property(e => e.AlbumId).HasColumnName("albumId");

      builder.Property(e => e.AlbumTitleAr).HasColumnName("albumTitleAr").HasMaxLength(100).IsRequired();
      builder.Property(e => e.AlbumTitleEn).HasColumnName("albumTitleEn").HasMaxLength(100).IsRequired();
      builder.Property(e => e.DescriptionAr).HasColumnName("descriptionAr");
      builder.Property(e => e.DescriptionEn).HasColumnName("descriptionEn");
      builder.Property(e => e.AlbumDate).HasColumnName("albumDate").HasColumnType("smalldatetime");
      builder.Property(e => e.Keywords).HasColumnName("Keywords");
      builder.Property(e => e.ForCompany).HasColumnName("forCompany").IsRequired();
      builder.Property(e => e.DisplayAlsoAt).HasColumnName("displayAlsoAt").IsRequired();
      builder.Property(e => e.Approved).HasColumnName("approved").IsRequired();
      builder.Property(e => e.Enabled).HasColumnName("enabled").IsRequired();

      builder.Property(e => e.SchoolId).HasColumnName("schoolId");
      builder.Property(e => e.StageId).HasColumnName("stageId");
      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");
      builder.Property(e => e.CategoryId).HasColumnName("categoryId");

      builder.HasOne(e => e._School)
            .WithMany(d => d.Albums)
            .HasForeignKey(e => e.SchoolId)
            .HasConstraintName("FK_schools_albums");

      builder.HasOne(e => e._Department)
            .WithMany(d => d.Albums)
            .HasForeignKey(e => e.StageId)
            .HasConstraintName("FK_departments_albums");

      builder.HasOne(e => e._EmployeeJob)
            .WithMany(d => d.Albums)
            .HasForeignKey(e => e.EmpJobId)
            .HasConstraintName("FK_employeesJobs_albums");

      builder.HasOne(e => e._MediaCategory)
            .WithMany(d => d.Albums)
            .HasForeignKey(e => e.CategoryId)
            .HasConstraintName("FK_mediaCategories_albums");

    }
  }
}