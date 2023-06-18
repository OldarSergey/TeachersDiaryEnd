using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;
using TeachersDiary.Entities;

namespace TeachersDiary.Configurations
{
    public class AchievementEntityTypeConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.HasKey(ac => ac.Id)
                 .HasName("PK_Achievements_Id");

            builder.Property(ac => ac.Name)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
            
            builder.Property(ac => ac.FilePath)
           .IsRequired()
           .HasMaxLength(500)
           .HasColumnType("nvarchar");

            builder.Property(ac => ac.Date)
                .HasColumnType("datetime");


        }
    }


   
}
