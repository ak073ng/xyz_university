using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/student_courses")]
    public class StudentCourseController : ControllerBase
    {
        private StudentCourseRepository StudentCoursesRepo;

        public StudentCourseController(StudentDbContext dbContext)
        {
            StudentCoursesRepo = new StudentCourseRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllStudentCourses()
        {
            return Ok(StudentCoursesRepo.StudentCourses());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetStudentCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentCoursesRepo.getStudentCourseById(id));
        }


        [HttpPost]
        public ActionResult<Task> AddStudentCourse([FromBody] StudentCourse studentCourse)
        {
            if (studentCourse == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentCoursesRepo.AddStudentCourse(studentCourse));
        }

        [HttpPut]
        public ActionResult<Task> UpdateStudentCourse([FromBody] StudentCourse studentCourse)
        {
            if (studentCourse == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentCoursesRepo.UpdateStudentCourse(studentCourse));
        }

        [HttpDelete("{id}")]
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
