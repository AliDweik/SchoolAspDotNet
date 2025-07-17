using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using School.Data.Repos;
using School.Dtos;
using School.Models;

namespace School.Controllers
{
    [Route("api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolRepoInterface _repository;
        private readonly IMapper _mapper;

        public SchoolController(SchoolRepoInterface repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<StudentReadDto>> GetAllStudents()
        {
            //return _mapper.Map<List<StudentReadDto>>(_repository.GetAllStudents());
            var students = _repository.GetAllStudents();

            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
            //return _repository.GetAllStudents();
        }

        [HttpPost]
        public ActionResult <StudentReadDto> CreateStudent(StudentCreateDto student)
        {
            var studentModel = _mapper.Map<Student>(student);

            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentRead = _mapper.Map<StudentReadDto>(studentModel);

            return studentRead;
            
            // TODO
            //return student;
            //return CreatedAtRoute(nameof(GetStudent))
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteStudent(Guid Id)
        {
            var studentFromRepo = _repository.GetStudent(Id);
            if (studentFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(studentFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateStudent(Guid Id, StudentUpdateDto student)
        {
            var studentFromRepo = _repository.GetStudent(Id);
            if (studentFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(student, studentFromRepo);

            _repository.UpdateStudent(studentFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpGet("{Id}", Name = "GetStudentById")]
        public ActionResult<StudentReadDto> GetStudent(Guid Id)
        {
            var studentFromRepo = _repository.GetStudent(Id);
            if (studentFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentReadDto>(studentFromRepo));
            //return _repository.GetStudent(Id);
            //return _mapper.Map<StudentReadDto>(studentFromRepo);
        }

    }
}
