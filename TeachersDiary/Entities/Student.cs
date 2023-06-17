using System.Text.RegularExpressions;

namespace TeachersDiary.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
        public ICollection<StudentAchievement> StudentAchievements { get; set; }



    }
}
