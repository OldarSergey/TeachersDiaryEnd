using Microsoft.EntityFrameworkCore;
using TeachersDiary.Data;
using TeachersDiary.Entities;

namespace TeachersDiary.Service
{
    public class AchievementService : IAchievementService
    {
        private readonly ApplicationDbContext _context;

        public AchievementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAchievementAsync(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            await _context.SaveChangesAsync();
            return achievement.Id;
        }

        public async Task<int> AddOrUpdateAchievementAsync(Achievement achievement)
        {
            var existingAchievement = await _context.Achievements
                .FirstOrDefaultAsync(a => a.Name == achievement.Name || a.FilePath == achievement.FilePath);

            if (existingAchievement == null)
            {
                _context.Achievements.Add(achievement);
                await _context.SaveChangesAsync();

                return achievement.Id;
            }
            else
            {
                existingAchievement.Name = achievement.Name;
                existingAchievement.FilePath = achievement.FilePath;
                existingAchievement.Date = achievement.Date;

                _context.Achievements.Update(existingAchievement);
                await _context.SaveChangesAsync();

                return existingAchievement.Id;
            }
        }



        public async Task<List<Achievement>> GetAchievementsAllAsync()
        {
            return _context.Achievements
                .Where(ac => ac.IsDeleted == false)
                .ToList();
        }

        public Task<List<Achievement>> GetAchievementsAllAsync(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
