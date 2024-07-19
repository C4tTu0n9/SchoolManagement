using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Repository.Models
{
    public partial class PRN212_Student_ManagementContext : DbContext
    {
        public PRN212_Student_ManagementContext()
        {
        }

        public PRN212_Student_ManagementContext(DbContextOptions<PRN212_Student_ManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnectionStringDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Mark1).HasColumnName("Mark");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Marks.StudentId");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Marks.SubjectId");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.StudentId });

                entity.ToTable("StudentClass");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_StudentClass.ClassId");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentClass.StudentId");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubjectTeacher>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.TeacherId, e.ClassId });

                entity.ToTable("SubjectTeacher");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_SubjectTeacher.ClassId");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_SubjectTeacher.SubjectId");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_SubjectTeacher.TeacherId");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
