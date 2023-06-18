using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TeachersDiary.Entities.DTO
{
    public class InputGroup
    {
        [Required]
        [StringLength(100, ErrorMessage = "Max length is {1}")]
        [Display(Name = "Название группы")]
        public string Name { get; set; }
    }
}
