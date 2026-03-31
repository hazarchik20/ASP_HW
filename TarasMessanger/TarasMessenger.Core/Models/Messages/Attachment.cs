using System;
using System.Collections.Generic;
using System.Text;

namespace TarasMessenger.Core.Models.Messages
{
    public class Attachment
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; } 
        public long Size { get; set; }
        public string ContentType { get; set; }

        public Guid MessageId { get; set; }
        public MessageBase Message { get; set; }
    }
}
