using System;

namespace TarasMessenger.Core.Models.Messages;

public class MessageBase
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }

    public string? Text { get; set; }

    public DateTime SendAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual IList<Attachment> Attachments { get; set; } = new List<Attachment>();
}