using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private StudentRepository StudentsRepo = new StudentRepository();

        [HttpGet("getStudents")]
        public ActionResult<Task> GetAllStudents()
        {
            return Ok(StudentsRepo.Students());
        }

        [HttpGet("getStudent/{id}")]
        public ActionResult<Task> GetStudentById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }
                
            return Ok(StudentsRepo.getStudentById(id));
        }

        [HttpPost("addStudent")]
        public ActionResult<Task> AddStudent([FromBody] Student student)
        {
            if(student == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentsRepo.AddStudent(student));
        }
        
        [HttpPut("updateStudent")]
        public ActionResult<Task> PutUpdateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentsRepo.UpdateStudent(student));
        }

        [HttpDelete("deleteStudent/{id}")]
        public ActionResult<Task> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentsRepo.DeleteStudent(id));
        }
    }
}
