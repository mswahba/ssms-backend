using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SSMS.Models
{
    public partial class test1Context : DbContext
    {
        public virtual DbSet<DocTypes> DocTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDocs> UsersDocs { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8GK916E;Database=test1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocTypes>(entity =>
            {
                entity.HasKey(e => e.DocTypeId);

                entity.ToTable("docTypes");

                entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

                entity.Property(e => e.DocTypeAr)
                    .HasColumnName("docTypeAr")
                    .HasMaxLength(50);

                entity.Property(e => e.DocTypeEn)
                    .HasColumnName("docTypeEn")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("lastLogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscribeDate)
                    .HasColumnName("subscribeDate")
                    .HasColumnType("date");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(25);

                entity.Property(e => e.UserType).HasColumnName("userType");
            });

            modelBuilder.Entity<UserDocs>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DocTypeId });

                entity.ToTable("usersDocs");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

                entity.Property(e => e.FilePath)
                    .HasColumnName("filePath")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("userTypes");

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.Property(e => e.UserTypeName)
                    .HasColumnName("userType")
                    .HasMaxLength(25);
            });
        }
    }
}
