namespace TeachersDiary.Entities
{
    public class StudentAchievement
    {
        public int StudentId { get; set; }
        public int AchievementId { get; set; }
        public int Order { get; set; }

        public Student Student { get; set; }
        public Achievement Achievement { get; set; }
    }
}
