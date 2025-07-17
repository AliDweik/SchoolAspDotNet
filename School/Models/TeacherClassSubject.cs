using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class TeacherClassSubject
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Teacher")]
        [Required]
        public Guid TeacherId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Class")]
        [Required]
        public Guid ClassId {  get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Subject")]
        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public string Schedule { get; set; }

        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public Class Subject { get; set; }
    }
}
