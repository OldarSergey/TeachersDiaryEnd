using TeachersDiary.Entities;

namespace TeachersDiary.Service
{
    public interface IAchievementService
    {
        public Task<List<Achievement>> GetAchievementsAllAsync(int studentId);
        Task<int> AddAchievementAsync(Achievement achievement);
        public Task<int> AddOrUpdateAchievementAsync(Achievement achievement);
    }
}
