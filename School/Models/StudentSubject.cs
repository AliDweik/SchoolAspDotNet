using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class StudentSubject
    {
        [ForeignKey("Student")]
        [Key, Column(Order = 0)]
        public Guid StudentId { get; set; }

        [ForeignKey("Subject")]
        [Key, Column(Order = 1)]
        public Guid SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }

    }
}
