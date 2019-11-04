using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ContactUsMessageConfig : IEntityTypeConfiguration<ContactUsMessage>
  {
    public void Configure(EntityTypeBuilder<ContactUsMessage> builder)
    {
      builder.HasKey(e => e.MessageId);
      builder.ToTable("contactUsMessages");

      builder.Property(e => e.MessageId).HasColumnName("messageId").ValueGeneratedOnAdd();
      builder.Property(e => e.SenderName).HasColumnName("senderName").HasMaxLength(50).IsRequired();
      builder.Property(e => e.Email).HasColumnName("email");
      builder.Property(e => e.Mobile).HasColumnName("mobile");
      builder.Property(e => e.MessageTitle).HasColumnName("messageTitle").HasMaxLength(75).IsRequired();
      builder.Property(e => e.MessageText).HasColumnName("messageText").HasMaxLength(1500).IsRequired();
      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");
      builder.Property(e => e.ReplayNotes).HasColumnName("replayNotes").HasMaxLength(100);
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(c => c.EmpJob)
            .WithMany(e => e.ContactUsMessages)
            .HasForeignKey(c => c.EmpJobId)
            .HasConstraintName("FK_employeesJobs_contactUsMessages");

    }
  }
}
