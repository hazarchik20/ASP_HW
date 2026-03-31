using System;
using System.Collections.Generic;
using System.Text;
using TarasMessenger.Core.Models.Messages;

namespace TarasMessenger.Core.Models
{
    public class Chat
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Guid> UserIds { get; set; }
        public List<User> Users { get; set; }

        public bool IsPrivate { get; set; } 
        public bool IsPublic { get; set; }
        public IEnumerable<Guid> MessageIds { get; set; }
        public List<MessageBase> Messages { get; set; }
    }
}
