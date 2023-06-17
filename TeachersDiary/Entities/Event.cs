namespace TeachersDiary.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public DateTime Date{ get; set; }
        public string Description { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
