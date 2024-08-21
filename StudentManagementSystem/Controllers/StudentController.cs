using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private ApplicationDbContext _context;

        public StudentController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> getAllStudent()
        {
            return _context.Students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student getStudentById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void addStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges(); ;


        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void updateStudentDetais(int id, [FromBody] Student student)
        {

            var updatedStudent = _context.Students.FirstOrDefault(x=> x.Id == id);
            updatedStudent.FirstName = student.FirstName;
            updatedStudent.LastName = student.LastName;
            updatedStudent.Email = student.Email;
            updatedStudent.Age = student.Age;
            updatedStudent.City = student.City;
            _context.Students.Update(updatedStudent);
            _context.SaveChanges(); 
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void deleteStudentDetails(int id)
        {
            var stdId = _context.Students.Find(id);
            _context.Students.Remove(stdId);
            _context.SaveChanges();
        }
    }
}
