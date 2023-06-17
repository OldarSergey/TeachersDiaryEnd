using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachersDiary.Entities;

namespace TeachersDiary.Configurations
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id)
                .HasName("PK_Grops_Id");

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("nvarchar");

            builder.HasOne(g => g.Teacher)
                .WithMany(t => t.Groups)
                .HasForeignKey(g => g.TeacherId)
                .HasConstraintName("FK_Groups_TeacherId_Teacher_Id");

        }
    }
}
