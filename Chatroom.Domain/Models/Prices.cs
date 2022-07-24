namespace Chatroom.Domain.Models
{
    /// <summary>
    /// Model from payload of Share price API.
    /// </summary>
    public class Prices
    {
        public List<SharePrice> Symbols { get; set; }
    }
}
