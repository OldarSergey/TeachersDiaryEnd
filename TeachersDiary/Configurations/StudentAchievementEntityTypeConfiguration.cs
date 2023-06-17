using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachersDiary.Entities;

namespace TeachersDiary.Configurations
{
    public class StudentAchievementEntityTypeConfiguration : IEntityTypeConfiguration<StudentAchievement>
    {
        public void Configure(EntityTypeBuilder<StudentAchievement> builder)
        {
            builder.HasKey(pt => new { pt.StudentId, pt.AchievementId })
               .HasName("PK_StudentAchievements_StudentId_AchievementId");

            builder.Property(sa => sa.Order)
                .HasColumnType("integer");

            builder.HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAchievements)
                .HasForeignKey(sa => sa.StudentId)
                .HasConstraintName("FK_StudentAchievements_StudentId_Student_Id");

            builder.HasOne(sa => sa.Achievement)
              .WithMany(a => a.StudentAchievements)
              .HasForeignKey(sa => sa.AchievementId)
              .HasConstraintName("FK_StudentAchievements_AchievementId_Achievement_Id");
        }
    }
}
