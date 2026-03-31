using Microsoft.EntityFrameworkCore;
using TarasMessanger.Storage;
using TarasMessenger.Core.Models.Messages;


namespace TarasMessanger.Web.Services;

public class MessageService
{
    private DataContext _context;

    public MessageService(DataContext context)
    {
        _context = context;
    }

    public async Task AddMessage(MessageBase message)
    {
        _context.MessageBases.Add(message);
        await _context.SaveChangesAsync();
    }
    
    public Task<List<MessageBase>> GetMessages(Guid chatId, int limit, int offset)
    {
        return _context.MessageBases
            .Include(x => x.User)
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .Where(x => x.ChatId == chatId && !x.IsDeleted)
            .OrderByDescending(x => x.SendAt)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }
    public async Task DeleteMessage(Guid messageId)
    {
        var message = await _context.MessageBases.FindAsync(messageId);
        if (message == null) return;

        message.IsDeleted = true;
        await _context.SaveChangesAsync();
    }
    public async Task EditMessage(Guid messageId, string newText)
    {
        var message = await _context.MessageBases.FindAsync(messageId);
        if (message == null) return;

        message.Text = newText;
        await _context.SaveChangesAsync();
    }
    public Task<List<MessageBase>> SearchMessages(string text)
    {
        return _context.MessageBases
            .Where(m => m.Text.Contains(text))
            .ToListAsync();
    }
}