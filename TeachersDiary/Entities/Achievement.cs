namespace TeachersDiary.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public ICollection<StudentAchievement> StudentAchievements { get; set; }
    }
}
