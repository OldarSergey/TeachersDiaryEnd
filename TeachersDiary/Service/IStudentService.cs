using TeachersDiary.Entities;

namespace TeachersDiary.Service
{
    public interface IStudentService
    {
        public Task AddStudentAsync(Student newStudent);
        public Task DeleteStudentAsync(int id);
        public Task<List<Student>> GetAllStudentsByIdAsync(int userId);
        public Task<List<Student>> GetAllStudentsAsync(int userId);
        public Task<List<Student>> GetStudentByIdAsync(string studentName, int userId);
        public Task<List<Student>> SortStudentFirstName(int userId);
        public Task<List<Student>> SortStudentLastName(int userId);
        public Task<List<Student>> SortStudentGroup(int userId);
        public Task<List<Student>> SearchStudentFirstNameAsync(string firstNameint, int userId);
        public Task<List<Achievement>> GetAchievementsAllAsync(int studentId);
        public Task<bool> UploadFile(IFormFile file);


    }
}
