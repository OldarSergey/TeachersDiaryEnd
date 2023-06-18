

using TeachersDiary.Entities;

namespace TeachersDiary.Service
{
    public interface IGroupService
    {
        public Task AddGroupAsync(Group newGroup);
        public Task<List<Group>> GetAllGroupsAsync();
        public Task<List<Group>> GetGroupByIdAsync(int idUser);
    }
}
