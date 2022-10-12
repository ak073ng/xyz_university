using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/studentFee")]
    public class StudentFeeController : ControllerBase
    {
        private StudentFeeRepository StudentFeesRepo = new StudentFeeRepository();

        [HttpGet("getStudentFees")]
        public ActionResult<Task> GetAllStudentCourses()
        {
            return Ok(StudentFeesRepo.StudentFees);
        }

        [HttpGet("getStudentFee/{id}")]
        public ActionResult<Task> GetStudentCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(StudentFeesRepo.getStudenFeeById(id));
        }

        [HttpPost("addStudentFee")]
        public ActionResult<Task> AddStudentCourse([FromBody] StudentFee studentFee)
        {
            if (studentFee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentFeesRepo.AddStudentFee(studentFee));
        }

        [HttpPut("updateStudentFee")]
        public ActionResult<Task> UpdateStudentCourse([FromBody] StudentFee studentFee)
        {
            if (studentFee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(StudentFeesRepo.UpdateStudentFee(studentFee));
        }

        [HttpDelete("deleteStudentFee/{id}")]
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
