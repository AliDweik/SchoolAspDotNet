using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace School.Models
{
    public class Subject
    {
        [Key]
        public Guid Id {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Department { get; set; }


    }
}
