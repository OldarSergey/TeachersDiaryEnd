using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachersDiary.Entities;

namespace TeachersDiary.Configurations
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(ac => ac.Id)
                 .HasName("PK_Events_Id");

            builder.Property(ac => ac.Name)
                .HasMaxLength(500)
                .HasColumnType("nvarchar");

            builder.Property(ac => ac.Date)
                .HasColumnType("datetime");

            builder.Property(ac => ac.Description)
             .HasMaxLength(500)
             .HasColumnType("nvarchar");

            builder.HasOne(ac => ac.Teacher)
                .WithMany(t => t.Events)
                .HasForeignKey(ac => ac.TeacherId)
                .HasConstraintName("FK_Events_TeacherId_Teachers_Id");
        }
    }
}
