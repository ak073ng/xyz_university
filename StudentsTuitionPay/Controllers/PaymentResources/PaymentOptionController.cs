using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Payment;
using StudentsTuitionPay.Models.Payment.Implementations;
using StudentsTuitionPay.Models.Payment.Utility;

namespace StudentsTuitionPay.Controllers.PaymentResources
{
    [ApiController]
    [Route("api/payment_options")]
    public class PaymentOptionController : ControllerBase
    {
        private PaymentOptionRepository PaymentOptionsRepo;

        public PaymentOptionController(PaymentDbContext dbContext)
        {
            PaymentOptionsRepo = new PaymentOptionRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllPaymentOptions()
        {
            return Ok(PaymentOptionsRepo.PaymentOptions());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetPaymentOptionById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(PaymentOptionsRepo.getPaymentOptionById(id));
        }


        [HttpPost]
        public ActionResult<Task> AddPaymentOption([FromBody] PaymentOption paymentOption)
        {
            if (paymentOption == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentOptionsRepo.AddPaymentOption(paymentOption));
        }


        [HttpPut]
        public ActionResult<Task> UpdatePaymentOption([FromBody] PaymentOption paymentOption)
        {
            if (paymentOption == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentOptionsRepo.UpdatePaymentOption(paymentOption));
        }

        [HttpDelete("{id}")]
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
