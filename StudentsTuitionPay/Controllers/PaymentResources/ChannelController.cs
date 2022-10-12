using Microsoft.AspNetCore.Mvc;
using StudentsTuitionPay.Models.Payment;
using StudentsTuitionPay.Models.Payment.Implementations;

namespace StudentsTuitionPay.Controllers.PaymentResources
{
    [ApiController]
    [Route("api/channel")]
    public class ChannelController : ControllerBase
    {
        private ChannelRepository ChannelsRepo = new ChannelRepository();

        [HttpGet("getChannels")]
        public ActionResult<Task> GetAllChannels()
        {
            return Ok(ChannelsRepo.Channels());
        }

        [HttpGet("getChannel/{id}")]
        public ActionResult<Task> GetChannelById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(ChannelsRepo.getChannelById(id));
        }


        [HttpPost("addChannel")]
        public ActionResult<Task> AddChannel([FromBody] Channel channel)
        {
            if (channel == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(ChannelsRepo.AddChannel(channel));
        }


        [HttpPut("updateChannel")]
        public ActionResult<Task> UpdateChannel([FromBody] Channel channel)
        {
            if (channel == null)
            {
                return BadRequest("The request's body cannot be null or empty");
            }

            return Ok(ChannelsRepo.UpdateChannel(channel));
        }

        [HttpDelete("deleteChannel/{id}")]
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
