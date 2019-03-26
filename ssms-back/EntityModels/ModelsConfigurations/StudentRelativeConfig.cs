using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StudentRelativeConfig : IEntityTypeConfiguration<StudentRelative>
  {
    public void Configure(EntityTypeBuilder<StudentRelative> builder)
    {
      builder.HasKey(e => e.StudentRelativeId);

      builder.ToTable("studentsRelatives");

      builder.Property(e => e.StudentRelativeId).HasColumnName("studentRelativeId");
      builder.Property(e => e.StudentId).HasColumnName("studentId").HasColumnType("char(10)").HasMaxLength(10);
      builder.Property(e => e.RelationId).HasColumnName("relationId");
      builder.Property(e => e.RelativeId).HasColumnName("relativeId");
      builder.Property(e => e.Priority).HasColumnName("priority");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.HasOne(s => s._Student)
                .WithMany(p => p.StudentsRelatives)
                .HasForeignKey(s => s.StudentId)
                .HasConstraintName("FK_students_studentsRelatives");
      
      builder.HasOne(s => s._Relation)
                .WithMany(p => p.StudentsRelatives)
                .HasForeignKey(s => s.RelationId)
                .HasConstraintName("FK_relations_studentsRelatives");

      builder.HasOne(s => s._Relative)
                .WithMany(p => p.StudentsRelatives)
                .HasForeignKey(s => s.RelativeId)
                .HasConstraintName("FK_relatives_studentsRelatives");

      builder.HasOne(e => e._User)
              .WithMany(u => u.StudentsRelatives)
              .HasForeignKey(e => e.IssuerId)
              .HasConstraintName("FK_users_studentsRelatives");

    }
  }
}