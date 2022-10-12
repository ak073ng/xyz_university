using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyController : ControllerBase
    {
        private FacultyRepository FacultyRepo = new FacultyRepository();

        [HttpGet("getFaculties")]
        public ActionResult<Task> GetAllFacalties()
        {
            return Ok(FacultyRepo.Faculties);
        }

        [HttpGet("getFaculty/{id}")]
        public ActionResult<Task> GetFacaltyById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(FacultyRepo.getFacultyById(id));
        }

        [HttpPost("addFaculty")]
        public ActionResult<Task> AddFacalty([FromBody] Faculty faculty)
        {
            if (faculty == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(FacultyRepo.AddFaculty(faculty));
        }

        [HttpPut("updateFaculty")]
        public ActionResult<Task> UpdateFacalty([FromBody] Faculty faculty)
        {
            if (faculty == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(FacultyRepo.UpdateFaculty(faculty));
        }

        [HttpDelete("deleteFaculty/{id}")]
        public ActionResult<Task> DeleteFacalty(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(FacultyRepo.DeleteFaculty(id));
        }
    }
}
