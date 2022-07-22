using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Domain.Models
{
    public class ChatMessage
    {
        public string User { get; set; }
        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
    }
}
