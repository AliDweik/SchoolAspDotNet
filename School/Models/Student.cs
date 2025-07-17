using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Student
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
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        
        /*[ForeignKey("Class")]
        public Guid ClassId { get; set; }
        public Class Class { get; set; }*/
    }
}
