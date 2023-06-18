using Microsoft.EntityFrameworkCore;
using TeachersDiary.Data;
using TeachersDiary.Entities;

namespace TeachersDiary.Service
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public StudentService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddStudentAsync(Student newStudent)
        {
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentsAsync(int userId)
        {
            return _context.Students
              .Where(s => s.IsDeleted == false && s.Group.TeacherId == userId)
              .Include(s => s.Group)
              .ToList();
        }

        public async Task<List<Student>> GetAllStudentsByIdAsync(int userId)
        {
            return _context.Students
               .Where(s => s.IsDeleted == false && s.Group.TeacherId == userId)
               .Include(s => s.Group)
               .ToList();
        }

        public async Task<List<Student>> GetStudentByIdAsync(string studentName, int userId)
        {
            return _context.Students
                 .Where(s => s.IsDeleted == false && s.FirstName == studentName && s.Group.TeacherId == userId)
                 .Include(s => s.Group)
                 .ToList();
        }

        public async Task<List<Student>> SearchStudentFirstNameAsync(string firstName, int userId)
        {
            return _context.Students
                .Where(s => s.IsDeleted == false && s.FirstName == firstName && s.Group.TeacherId == userId)
                .Include(e => e.Group)
                .ToList();
        }

        public async Task<List<Student>> SortStudentFirstName(int userId)
        {
            return _context.Students
               .Where(s => s.IsDeleted == false && s.Group.TeacherId == userId)
               .OrderBy(s => s.FirstName)
               .Include(s => s.Group)
               .ToList();
        }

        public async Task<List<Student>> SortStudentGroup(int userId)
        {
            return _context.Students
             .Include(s => s.Group)
             .Where(s => s.IsDeleted == false && s.Group.TeacherId == userId)
             .OrderBy(s => s.Group.Title)
             .ToList();
        }

        public async Task<List<Student>> SortStudentLastName(int userId)
        {
            return _context.Students
              .Where(s => s.IsDeleted == false && s.Group.TeacherId == userId)
              .OrderBy(s => s.LastName)
              .Include(s => s.Group)
              .ToList();
        }
        public async Task<List<Achievement>> GetAchievementsAllAsync(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.StudentAchievements)
                .ThenInclude(sa => sa.Achievement)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student != null)
            {
                var achievements = student.StudentAchievements
                    .Select(sa => sa.Achievement)
                    .ToList();

                return achievements;
            }

            return new List<Achievement>();
        }

		public async Task<bool> UploadFile(IFormFile file)
		{
			try
			{
				if (file.Length > 0)
				{
					string webRootPath = _webHostEnvironment.WebRootPath;
					string uploadsPath = Path.Combine(webRootPath, "UploadedFiles");

					if (!Directory.Exists(uploadsPath))
					{
						Directory.CreateDirectory(uploadsPath);
					}

					string filePath = Path.Combine(uploadsPath, file.FileName);

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await file.CopyToAsync(fileStream);
					}

					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("File Copy Failed", ex);
			}
		}

		public async Task DeleteStudentAsync(int id)
		{
            var student = _context.Students
                .Where(c => c.IsDeleted == false && c.Id == id)
                .FirstOrDefault();
            if (student != null)
                student.IsDeleted = true;

            await _context.SaveChangesAsync();

		}
	}

}

