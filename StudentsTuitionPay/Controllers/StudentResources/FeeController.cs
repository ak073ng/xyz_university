using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/fees")]
    public class FeeController : ControllerBase
    {
        private FeeRepository FeesRepo;

        public FeeController(StudentDbContext dbContext)
        {
            FeesRepo = new FeeRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllFees()
        {
            return Ok(FeesRepo.Fees());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetFeeById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(FeesRepo.getFeeById(id));
        }

        [HttpPost]
        public ActionResult<Task> AddFee([FromBody] Fee fee)
        {
            if (fee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(FeesRepo.AddFee(fee));
        }

        [HttpPut]
        public ActionResult<Task> UpdateFee([FromBody] Fee fee)
        {
            if (fee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(FeesRepo.UpdateFee(fee));
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteFee(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(FeesRepo.DeleteFee(id));
        }
    }
}
