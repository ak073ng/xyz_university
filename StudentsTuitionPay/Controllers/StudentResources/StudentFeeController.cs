using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/student_fees")]
    public class StudentFeeController : ControllerBase
    {
        private StudentFeeRepository StudentFeesRepo;

        public StudentFeeController(StudentDbContext dbContext)
        {
            StudentFeesRepo = new StudentFeeRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllStudentCourses()
        {
            return Ok(StudentFeesRepo.StudentFees());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetStudentCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentFeesRepo.getStudenFeeById(id));
        }

        [HttpPost]
        public ActionResult<Task> AddStudentCourse([FromBody] StudentFee studentFee)
        {
            if (studentFee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentFeesRepo.AddStudentFee(studentFee));
        }

        [HttpPut]
        public ActionResult<Task> UpdateStudentCourse([FromBody] StudentFee studentFee)
        {
            if (studentFee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentFeesRepo.UpdateStudentFee(studentFee));
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteStudentCourse(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentFeesRepo.DeleteStudentFee(id));
        }
    }
}
