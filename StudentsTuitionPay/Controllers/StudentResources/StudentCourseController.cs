using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/studentCourse")]
    public class StudentCourseController : ControllerBase
    {
        private StudentCourseRepository StudentCoursesRepo = new StudentCourseRepository();

        [HttpGet("getStudentCourses")]
        public ActionResult<Task> GetAllStudentCourses()
        {
            return Ok(StudentCoursesRepo.StudentCourses);
        }

        [HttpGet("getStudentCourse/{id}")]
        public ActionResult<Task> GetStudentCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentCoursesRepo.getStudentCourseById(id));
        }


        [HttpPost("addStudentCourse")]
        public ActionResult<Task> AddStudentCourse([FromBody] StudentCourse studentCourse)
        {
            if (studentCourse == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentCoursesRepo.AddStudentCourse(studentCourse));
        }

        [HttpPut("updateStudentCourse")]
        public ActionResult<Task> UpdateStudentCourse([FromBody] StudentCourse studentCourse)
        {
            if (studentCourse == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentCoursesRepo.UpdateStudentCourse(studentCourse));
        }

        [HttpDelete("deleteStudentCourse/{id}")]
        public ActionResult<Task> DeleteStudentCourse(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentCoursesRepo.DeleteStudentCourse(id));
        }
    }
}
