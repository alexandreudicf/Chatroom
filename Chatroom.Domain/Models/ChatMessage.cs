﻿namespace Chatroom.Domain.Models
{
    /// <summary>
    /// This is the model that transfer message to the web.
    /// </summary>
    public class ChatMessage
    {
        public const string BotName = "Bot";

        public string User { get; set; }
        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
    }
}
