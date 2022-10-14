using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Payment.Interfaces;
using StudentsTuitionPay.Models.Payment.Utility;

namespace StudentsTuitionPay.Models.Payment.Implementations
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly PaymentDbContext DbContext;

        public ChannelRepository(PaymentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Channel>> Channels()
        {
            var List = await DbContext.Channels.Select(
                s => new Channel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<Channel> getChannelById(int id)
        {
            Channel Channel = await DbContext.Channels.Select(
                c => new Channel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }
            ).FirstOrDefaultAsync(c => c.Id == id);

            return Channel;
        }

        public async Task<Channel> AddChannel(Channel channel)
        {
            var Channel = new Channel()
            {
                Id = channel.Id,
                Name = channel.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.Channels.Add(Channel);

            await DbContext.SaveChangesAsync();

            return Channel;
        }

        public async Task<Channel> UpdateChannel(Channel channel)
        {
            var Channel = await DbContext.Channels.FirstOrDefaultAsync(c => c.Id == channel.Id);

            if(Channel != null)
            {
                Channel.Name = channel.Name;
                Channel.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }           

            return Channel;
        }

        public async Task DeleteChannel(int id)
        {
            var Channel = new Channel() { Id = id };

            DbContext.Channels.Attach(Channel);

            DbContext.Channels.Remove(Channel);

            await DbContext.SaveChangesAsync();
        }
        
    }
}
