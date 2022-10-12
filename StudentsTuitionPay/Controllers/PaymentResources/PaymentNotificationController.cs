using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Payment;
using StudentsTuitionPay.Models.Payment.Implementations;

namespace StudentsTuitionPay.Controllers.PaymentResources
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentNotificationController : ControllerBase
    {
        private PaymentNotificationRepository PaymentNotifsRepo = new PaymentNotificationRepository();
        //private PaymentOptionRepository PaymentOptionsRepo = new PaymentOptionRepository();
        //private ChannelRepository ChannelsRepo = new ChannelRepository();

        [HttpGet("getPayments")]
        public ActionResult<Task> GetAllPayments()
        {
            return Ok(PaymentNotifsRepo.PaymentNotifications());
        }

        [HttpGet("getPayment/{id}")]
        public ActionResult<Task> GetPaymentById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(PaymentNotifsRepo.getPaymentNotificationById(id));
        }


        [HttpPost("addPayment")]
        public ActionResult<Task> AddPayment([FromBody] PaymentNotification payment)
        {
            if (payment == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentNotifsRepo.AddPaymentNotif(payment));
        }


        [HttpPut("updatePayment")]
        public ActionResult<Task> UpdatePayment([FromBody] PaymentNotification payment)
        {
            if (payment == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(PaymentNotifsRepo.UpdatePaymentNotif(payment));
        }

        [HttpDelete("deletePayment/{id}")]
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
