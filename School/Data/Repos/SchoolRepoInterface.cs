using School.Models;

namespace School.Data.Repos
{
    public interface SchoolRepoInterface
    {
        public List<Student> GetAllStudents();
        public Student GetStudent(Guid Id);

        public void CreateStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(Student student);

        public void SaveChanges();
    }
}
