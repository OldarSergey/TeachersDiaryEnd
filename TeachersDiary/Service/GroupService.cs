
using TeachersDiary.Data;
using TeachersDiary.Entities;

namespace TeachersDiary.Service
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddGroupAsync(Group newGroup)
        {
            _context.Groups.Add(newGroup);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return _context.Groups
                .Where(g => g.IsDeleted == false)
                .ToList();
        }
        public async Task<List<Group>> GetGroupByIdAsync(int idUser)
        {
            return _context.Groups
                .Where(g => g.IsDeleted == false && g.TeacherId == idUser)
                .ToList();
        }
    }
}
