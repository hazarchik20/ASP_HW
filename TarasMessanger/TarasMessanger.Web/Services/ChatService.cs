using Microsoft.EntityFrameworkCore;
using TarasMessanger.Storage;
using TarasMessenger.Core.Models;

namespace TarasMessanger.Web.Services
{
    public class ChatService
    {
        private readonly DataContext _context;

        public ChatService(DataContext context)
        {
            _context = context;
        }

        public async Task<Chat> CreateChat(List<Guid> userIds)
        {
            var chat = new Chat
            {
                Id = Guid.NewGuid(),
                Users = await _context.Users.Where(u => userIds.Contains(u.Id)).ToListAsync()
            };

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return chat;
        }

        public Task<List<Chat>> GetUserChats(Guid userId)
        {
            return _context.Chats
                .Where(c => c.Users.Any(u => u.Id == userId))
                .ToListAsync();
        }
    }
}
