using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeachersDiary.Entities;
using TeachersDiary.Entities.DTO;
using TeachersDiary.Service;

namespace TeachersDiary.Pages
{
    public class AddStudentModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        private readonly UserManager<Teacher> _userManager;

        public int UserId { get; set; }
        public List<SelectListItem> GroupItems { get; set; }

        public AddStudentModel(IStudentService studentService, IGroupService groupService, UserManager<Teacher> userManager)
        {
            _studentService = studentService;
            _groupService = groupService;
            _userManager = userManager;
        }

        [BindProperty]
        public InputStudent InputStudent { get; set; }


        public IActionResult OnGetAddStudent(int id)
        {
            TempData["UserId"] = id.ToString();
            return RedirectToPage("AddStudent");
        }

        public async Task<IActionResult> OnGet()
        {
            if (!TempData.ContainsKey("UserId") || !int.TryParse(TempData["UserId"] as string, out int userId))
            {
                // Обработка ошибки, если UserId не найден или не удалось преобразовать в int
                return RedirectToPage("Index");
            }

            UserId = userId;
            await LoadGroup();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var student = new Student()
            {
                FirstName = InputStudent.FirstName,
                LastName = InputStudent.LastName,
                MiddleName = InputStudent.MiddleName,
                Email = InputStudent.Email,
                GroupId = InputStudent.SelectedValueGroup
            };
            await _studentService.AddStudentAsync(student);
            return RedirectToPage("Index");
        }

        private async Task LoadGroup()
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                List<Group> groups = await _groupService.GetGroupByIdAsync(int.Parse(userId));
                GroupItems = groups.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Title
                })
                .ToList();
            }
            catch (Exception ex)
            {
                // Обработайте исключение
            }
        }
    }
}
