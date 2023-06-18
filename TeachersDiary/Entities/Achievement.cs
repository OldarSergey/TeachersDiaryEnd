namespace TeachersDiary.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public DateTime Date { get; set; }

        public ICollection<StudentAchievement> StudentAchievements { get; set; }
    }
}
