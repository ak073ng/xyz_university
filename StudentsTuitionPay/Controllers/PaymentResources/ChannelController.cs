using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Payment;
using StudentsTuitionPay.Models.Payment.Implementations;
using StudentsTuitionPay.Models.Payment.Utility;

namespace StudentsTuitionPay.Controllers.PaymentResources
{
    [ApiController]
    [Route("api/channels")]
    public class ChannelController : ControllerBase
    {
        private ChannelRepository ChannelsRepo;

        public ChannelController(PaymentDbContext dbContext)
        {
            ChannelsRepo = new ChannelRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<Task> GetAllChannels()
        {
            return Ok(ChannelsRepo.Channels());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetChannelById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(ChannelsRepo.getChannelById(id));
        }


        [HttpPost]
        public ActionResult<Task> AddChannel([FromBody] Channel channel)
        {
            if (channel == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(ChannelsRepo.AddChannel(channel));
        }


        [HttpPut]
        public ActionResult<Task> UpdateChannel([FromBody] Channel channel)
        {
            if (channel == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(ChannelsRepo.UpdateChannel(channel));
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteChannel(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(ChannelsRepo.DeleteChannel(id));
        }
    }
}
