using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ArticleConfig : IEntityTypeConfiguration<Article>
  {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
      builder.HasKey(e => e.ArticleId);

      builder.ToTable("articles");

      builder.Property(e => e.ArticleId).HasColumnName("articleId");

      builder.Property(e => e.ArticleTitle).HasColumnName("articleTitle").HasMaxLength(100).IsRequired();
      builder.Property(e => e.ArticleText).HasColumnName("articleText").IsRequired();
      builder.Property(e => e.ArticleDate).HasColumnName("articleDate").HasColumnType("smalldatetime").IsRequired();
      builder.Property(e => e.AuthorName).HasColumnName("authorName");
      builder.Property(e => e.MainPhotoURL).HasColumnName("mainPhotoURL");
      builder.Property(e => e.PhotosURLs).HasColumnName("photosURLs");
      builder.Property(e => e.VideosURLs).HasColumnName("videosURLs");
      builder.Property(e => e.DisplayAlsoAt).HasColumnName("displayAlsoAt").IsRequired();
      builder.Property(e => e.ForCompany).HasColumnName("forCompany").IsRequired();
      builder.Property(e => e.Approved).HasColumnName("approved").IsRequired();
      builder.Property(e => e.Enabled).HasColumnName("enabled").IsRequired();

      builder.Property(e => e.SchoolId).HasColumnName("schoolId");
      builder.Property(e => e.StageId).HasColumnName("stageId");
      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.HasOne(e => e._School)
            .WithMany(d => d.Articles)
            .HasForeignKey(e => e.SchoolId)
            .HasConstraintName("FK_schools_articles");

      builder.HasOne(e => e._Department)
            .WithMany(d => d.Articles)
            .HasForeignKey(e => e.StageId)
            .HasConstraintName("FK_departments_articles");

      builder.HasOne(e => e._EmployeeJob)
            .WithMany(d => d.Articles)
            .HasForeignKey(e => e.EmpJobId)
            .HasConstraintName("FK_employeesJobs_articles");

    }
  }
}