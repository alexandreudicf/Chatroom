﻿namespace Chatroom.Domain.Models
{
    public class ChatMessage
    {
        public string User { get; set; }
        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
    }
}
