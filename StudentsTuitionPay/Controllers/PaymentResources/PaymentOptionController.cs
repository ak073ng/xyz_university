using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Payment;
using StudentsTuitionPay.Models.Payment.Implementations;

namespace StudentsTuitionPay.Controllers.PaymentResources
{
    [ApiController]
    [Route("api/paymentOption")]
    public class PaymentOptionController : ControllerBase
    {
        private PaymentOptionRepository PaymentOptionsRepo = new PaymentOptionRepository();

        [HttpGet("getPaymentOptions")]
        public ActionResult<Task> GetAllPaymentOptions()
        {
            return Ok(PaymentOptionsRepo.PaymentOptions());
        }

        [HttpGet("getPaymentOption/{id}")]
        public ActionResult<Task> GetPaymentOptionById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(PaymentOptionsRepo.getPaymentOptionById(id));
        }


        [HttpPost("addPaymentOption")]
        public ActionResult<Task> AddPaymentOption([FromBody] PaymentOption paymentOption)
        {
            if (paymentOption == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentOptionsRepo.AddPaymentOption(paymentOption));
        }


        [HttpPut("updatePaymentOption")]
        public ActionResult<Task> UpdatePaymentOption([FromBody] PaymentOption paymentOption)
        {
            if (paymentOption == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentOptionsRepo.UpdatePaymentOption(paymentOption));
        }

        [HttpDelete("deletePaymentOption/{id}")]
        public ActionResult<Task> DeletePaymentOption(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(PaymentOptionsRepo.DeletePaymentOption(id));
        }
    }
}
