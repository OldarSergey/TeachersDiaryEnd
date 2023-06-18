using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TeachersDiary.Data;
using TeachersDiary.Entities;
using TeachersDiary.Service;

namespace TeachersDiary.Pages
{
    public class AchievementsStudentModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IAchievementService _achievementService;
        private readonly ApplicationDbContext _context;

        [BindProperty(SupportsGet = true)]
        public int StudentId { get; set; }

        public List<Achievement> Achievements { get; set; }

        public AchievementsStudentModel(IStudentService studentService, IAchievementService achievementService, ApplicationDbContext context)
        {
            _studentService = studentService;
            _achievementService = achievementService;
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            if (StudentId != 0)
            {
                Achievements = await _studentService.GetAchievementsAllAsync(StudentId);
            }
            return Page();
        }
		public async Task<IActionResult> OnPostAddFile(IFormFile file, int studentId)
		{
			if (await _studentService.UploadFile(file))
			{
				string fileName = Path.GetFileName(file.FileName);
				string relativePath = Path.Combine("UploadedFiles", fileName);

				var achievement = new Achievement()
				{
					Name = fileName,
					FilePath = relativePath,
					Date = DateTime.Now
				};

				var achievementId = await _achievementService.AddOrUpdateAchievementAsync(achievement);

				var student = await _context.Students.FindAsync(studentId);
				if (student != null)
				{
					var existingStudentAchievement = await _context.StudentAchievements
						.FirstOrDefaultAsync(sa => sa.StudentId == student.Id && sa.AchievementId == achievementId);

					if (existingStudentAchievement == null)
					{
						var studentAchievement = new StudentAchievement
						{
							StudentId = student.Id,
							AchievementId = achievementId
						};

						_context.StudentAchievements.Add(studentAchievement);
						await _context.SaveChangesAsync();
					}
				}

				if (studentId != 0)
				{
					Achievements = await _studentService.GetAchievementsAllAsync(studentId);
				}
			}

			return Page();
		}




		public async Task<IActionResult> OnPostAchievements(int id)
        {
            StudentId = id;

            if (StudentId != 0)
            {
                Achievements = await _studentService.GetAchievementsAllAsync(StudentId);
            }

            return Page();
        }



    }
}
