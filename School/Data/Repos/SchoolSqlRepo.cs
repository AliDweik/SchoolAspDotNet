using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Data.Repos
{
    public class SchoolSqlRepo : SchoolRepoInterface
    {
        private readonly SchoolDBContext _context;

        public SchoolSqlRepo(SchoolDBContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);   
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(Guid Id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == Id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Update(student);
        }
    }
}
