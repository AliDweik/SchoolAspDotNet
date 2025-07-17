using System.ComponentModel.DataAnnotations;

namespace School.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public char Gender { get; set; }
    }
}
