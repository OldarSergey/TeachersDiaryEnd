using Microsoft.AspNetCore.Identity;

namespace TeachersDiary.Entities
{
    public class Teacher : IdentityUser<int>
    {
        public bool IsDeleted { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
