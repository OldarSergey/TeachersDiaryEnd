using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeachersDiary.Entities;

namespace TeachersDiary.Data
{
    public class ApplicationDbContext : IdentityDbContext<Teacher, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAchievement> StudentAchievements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


    }
}
