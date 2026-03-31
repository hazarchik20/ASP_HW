using System;
using System.Collections.Generic;
using System.Text;

namespace TarasMessenger.Core.Models.Messages
{
    public class MessageDto
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime SendAt { get; set; }
        public string UserName { get; set; }
    }
}
