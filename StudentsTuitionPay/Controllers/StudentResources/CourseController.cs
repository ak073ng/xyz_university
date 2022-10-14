using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private CourseRepository CoursesRepo;

        public CourseController(StudentDbContext dbContext)
        {
            CoursesRepo = new CourseRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllCourses()
        {
            return Ok(CoursesRepo.Courses());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(CoursesRepo.getCourseById(id));
        }

        [HttpPost]
        public ActionResult<Task> AddCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(CoursesRepo.AddCourse(course));
        }

        [HttpPut]
        public ActionResult<Task> UpdateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(CoursesRepo.UpdateCourse(course));
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteCourse(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(CoursesRepo.DeleteCourse(id));
        }
    }
}
