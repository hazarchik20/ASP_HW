using System;
using System.Collections.Generic;
using System.Text;

namespace NewChatApp.Core.Models.Chats
{
    public class ChatWithUserEntity : ChatEntity

    {
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
