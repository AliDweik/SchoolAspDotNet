using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) { }


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<TeacherClassSubject>()
                .HasKey(tcs => new { tcs.TeacherId, tcs.ClassId, tcs.SubjectId });
        
        }*/

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //TODO
        //public DbSet<StudentSubject> StudentSubjects { get; set; }
        //public DbSet<TeacherClassSubject> TeachersClassSubjects { get; set; }

    }
}