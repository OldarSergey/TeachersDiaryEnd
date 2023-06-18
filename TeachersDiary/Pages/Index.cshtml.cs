using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using TeachersDiary.Entities;
using TeachersDiary.Entities.DTO;
using TeachersDiary.Service;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TeachersDiary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGroupService _groupService;
        private readonly UserManager<Teacher> _userManager;
        private readonly IStudentService _studentService;

        [BindProperty]
        public InputGroup InputGroup { get; set; }

        [BindProperty]
        public IEnumerable<Student> StudentsList { get; set; }

        public int UserId { get; set; }

        public string SearchStudent { get; set; }
        public string SortStudent { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IGroupService groupService,
            UserManager<Teacher> userManager,
            IStudentService studentService)
        {
            _logger = logger;
            _groupService = groupService;
            _userManager = userManager;
            _studentService = studentService;
        }

        public async Task OnGet()
        {
            
            var userId = _userManager.GetUserId(User);
            if (!string.IsNullOrEmpty(userId))
            {
                UserId = int.Parse(userId);
                StudentsList = await _studentService.GetAllStudentsByIdAsync(UserId);
            }
            else
            {
                StudentsList = new List<Student>();
            }
        }

        public IActionResult OnGetAddStudent(int id)
        {
            TempData["UserId"] = id.ToString();
            return RedirectToPage("AddStudent");
        }

        public async Task<IActionResult> OnPostAddGroup()
        {
            if (!ModelState.IsValid)
                return Page();

            var userId = _userManager.GetUserId(User);

            var group = new Group()
            {
                Title = InputGroup.Name,
                TeacherId = int.Parse(userId)
            };
            await _groupService.AddGroupAsync(group);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSortStudent(string sortStudent)
        {
            var userId = _userManager.GetUserId(User);
            switch (sortStudent)
            {
                case "1":
                    StudentsList = await _studentService.GetAllStudentsAsync(int.Parse(userId));
                    return Page();

                case "2":
                    StudentsList = await _studentService.SortStudentFirstName(int.Parse(userId));
                    return Page();

                case "3":
                    StudentsList = await _studentService.SortStudentLastName(int.Parse(userId));
                    return Page();

                case "4":
                    StudentsList = await _studentService.SortStudentGroup(int.Parse(userId));
                    return Page();

                default:
                    return  Page();
            }

           
        }

        public async Task<IActionResult> OnPostSearchStudent(string searchStudent)
        {
            var userId = _userManager.GetUserId(User);
            StudentsList = await _studentService.SearchStudentFirstNameAsync(searchStudent,int.Parse(userId));
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToPage("Index");
        }
    }
}
