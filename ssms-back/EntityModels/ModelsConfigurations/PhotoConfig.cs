using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class PhotoConfig : IEntityTypeConfiguration<Photo>
  {
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
      builder.HasKey(e => e.PhotoId);

      builder.ToTable("photos");

      builder.Property(e => e.PhotoId).HasColumnName("photoId");

      builder.Property(e => e.PhotoTitleAr).HasColumnName("photoTitleAr").HasMaxLength(100).IsRequired();
      builder.Property(e => e.PhotoTitleEn).HasColumnName("photoTitleEn").HasMaxLength(100).IsRequired();
      builder.Property(e => e.DescriptionAr).HasColumnName("descriptionAr");
      builder.Property(e => e.DescriptionEn).HasColumnName("descriptionEn");
      builder.Property(e => e.PhotoDate).HasColumnName("photoDate").HasColumnType("smalldatetime").IsRequired();
      builder.Property(e => e.PhotoURL).HasColumnName("photoURL").IsRequired();
      builder.Property(e => e.ThumbURL).HasColumnName("thumbURL").IsRequired();
      builder.Property(e => e.MoreURL).HasColumnName("moreURL");
      builder.Property(e => e.Approved).HasColumnName("approved").IsRequired();
      builder.Property(e => e.Enabled).HasColumnName("enabled").IsRequired();

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");
      builder.Property(e => e.AlbumId).HasColumnName("albumId");

      builder.HasOne(e => e._EmployeeJob)
            .WithMany(d => d.Photos)
            .HasForeignKey(e => e.EmpJobId)
            .HasConstraintName("FK_employeesJobs_photos");

      builder.HasOne(e => e._Album)
            .WithMany(d => d.Photos)
            .HasForeignKey(e => e.AlbumId)
            .HasConstraintName("FK_albums_photos");

    }
  }
}