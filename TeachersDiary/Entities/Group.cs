namespace TeachersDiary.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Title { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
