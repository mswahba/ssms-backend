using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class UserDocConfig : IEntityTypeConfiguration<UserDoc>
  {
    public void Configure(EntityTypeBuilder<UserDoc> builder)
    {
      builder.HasKey(e => e.UserDocId);

      builder.ToTable("usersDocs");

      builder.Property(e => e.UserDocId)
                .HasColumnName("userDocId")
                .ValueGeneratedNever();

      builder.Property(e => e.DocTypeId).HasColumnName("docTypeId");

      builder.Property(e => e.FilePath)
                .HasColumnName("filePath")
                .HasMaxLength(15);

      builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("userId")
                .HasColumnType("char(10)");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.DocType)
                .WithMany(p => p.UsersDocs)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK_usersDocs_docTypes");

      builder.HasOne(d => d.User)
                .WithMany(p => p.UsersDocs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_usersDocs_users");

    }
  }
}