using Microsoft.EntityFrameworkCore;
using TarasMessanger.Storage;
using TarasMessenger.Core.Models;

namespace TarasMessanger.Web.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async  Task<User> GetUser(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
