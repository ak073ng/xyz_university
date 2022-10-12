namespace StudentsTuitionPay.Models.Payment.Interfaces
{
    public interface IChannelRepository
    {
        Task<IEnumerable<Channel>> Channels();
        Task<Channel> getChannelById (int id);
        Task<Channel> AddChannel(Channel channel);
        Task<Channel> UpdateChannel(Channel channel);
        Task DeleteChannel(int id);
    }
}
