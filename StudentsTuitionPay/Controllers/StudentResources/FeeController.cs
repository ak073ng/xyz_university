using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Student;
using StudentsTuitionPay.Models.Student.Implementations;

namespace StudentsTuitionPay.Controllers.StudentResources
{
    [ApiController]
    [Route("api/fee")]
    public class FeeController : ControllerBase
    {
        private FeeRepository FeesRepo = new FeeRepository();

        [HttpGet("getFees")]
        public ActionResult<Task> GetAllFees()
        {
            return Ok(FeesRepo.Fees);
        }

        [HttpGet("getFee/{id}")]
        public ActionResult<Task> GetFeeById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(FeesRepo.getFeeById(id));
        }

        [HttpPost("addFee")]
        public ActionResult<Task> AddFee([FromBody] Fee fee)
        {
            if (fee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(FeesRepo.AddFee(fee));
        }

        [HttpPut("updateFee")]
        public ActionResult<Task> UpdateFee([FromBody] Fee fee)
        {
            if (fee == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(FeesRepo.UpdateFee(fee));
        }

        [HttpDelete("deleteFee/{id}")]
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
