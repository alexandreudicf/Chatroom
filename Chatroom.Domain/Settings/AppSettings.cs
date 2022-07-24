namespace Chatroom.Domain.Settings
{
    /// <summary>
    /// Settings of the app.
    /// </summary>
    public class AppSettings
    {
        public string RabbitMQHostName { get; set; }
        public string QueueName { get; set; }
        public string SharePriceUri { get; set; }
        public int MaxMessagesDisplayed { get; set; }
    }
}
