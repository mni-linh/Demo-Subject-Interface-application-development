namespace AdminQLKetQuaHocTap
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=mdManageStudyResults")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Study_result> Study_result { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Subject_type> Subject_type { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.id_subject)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.id_teacher)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Faculty)
                .HasForeignKey(e => e.id_faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Faculty)
                .HasForeignKey(e => e.id_faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.Faculty)
                .HasForeignKey(e => e.id_faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.id_faculty)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Study_result)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.id_student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Study_result>()
                .Property(e => e.id_subject)
                .IsUnicode(false);

            modelBuilder.Entity<Study_result>()
                .Property(e => e.id_student)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.id_subject_type)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.id_faculty)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.id_subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Study_result)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.id_subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject_type>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Subject_type>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Subject_type)
                .HasForeignKey(e => e.id_subject_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.id_faculty)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.id_teacher)
                .WillCascadeOnDelete(false);
        }
    }
}
