using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public char Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public string Department { get; set; }

    }
}
