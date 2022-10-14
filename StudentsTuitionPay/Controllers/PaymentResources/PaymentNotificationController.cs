using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Payment;
using StudentsTuitionPay.Models.Payment.Implementations;
using StudentsTuitionPay.Models.Payment.Utility;

namespace StudentsTuitionPay.Controllers.PaymentResources
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentNotificationController : ControllerBase
    {
        private PaymentNotificationRepository PaymentNotifsRepo;

        public PaymentNotificationController(PaymentDbContext dbContext)
        {
            PaymentNotifsRepo = new PaymentNotificationRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllPayments()
        {
            return Ok(PaymentNotifsRepo.PaymentNotifications());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetPaymentById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(PaymentNotifsRepo.getPaymentNotificationById(id));
        }


        [HttpPost]
        public ActionResult<Task> AddPayment([FromBody] PaymentNotification payment)
        {
            if (payment == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentNotifsRepo.AddPaymentNotif(payment));
        }


        [HttpPut]
        public ActionResult<Task> UpdatePayment([FromBody] PaymentNotification payment)
        {
            if (payment == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentNotifsRepo.UpdatePaymentNotif(payment));
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeletePayment(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(PaymentNotifsRepo.DeletePaymentNotif(id));
        }
    }
}
