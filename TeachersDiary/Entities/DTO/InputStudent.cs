using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TeachersDiary.Entities;

namespace TeachersDiary.Entities.DTO
{
    public class InputStudent
    {
        [Required]
        [StringLength(100, ErrorMessage = "Max length is {1}")]
        [Display(Name = "Имя студента")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Max length is {1}")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "Max length is {1}")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Not a valid.")]
        [Display(Name = "Группа")]
        public int SelectedValueGroup { get; set; }
    }
}
