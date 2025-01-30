using CertStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CertStore.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Tests> Tests { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamCategory> ExamCategories { get; set; }
        public DbSet<FullCategory> FullCategories { get; set; }
        public DbSet<CertExam> CertExams { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserStaf> UserStafs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>()
                .HasOne(i => i.CertExam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(i => i.CertExamId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Exam>()
        //       .HasOne(e => e.Category)
        //       .WithMany(c => c.Exams)
        //       .HasForeignKey(e => e.CategoryId)
        //       .OnDelete(DeleteBehavior.Cascade);

        //}
    }
}
