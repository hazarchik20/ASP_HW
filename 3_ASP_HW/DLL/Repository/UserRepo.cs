using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class UserRepo : GeneralRepo<User>
    {
        private DataContext _context;
        public UserRepo(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersWithNameStartingWithAAsync()
        {
            return await _context.Set<User>().Where(u => u.Name.StartsWith("A")).ToListAsync();
        }
        public async Task<List<User>> GetUsersWithSubscriptionsAsync()
        {
            return await _context.Set<User>().Where(u => u.Subscriptions.Any()).ToListAsync();
        }
        public async Task<List<string>> GetUserNamesWithPremiumAsync(int count)
        {
            return await _context.Set<User>()
                .Where(u => u.Subscriptions.Any(s => s.Type == "Premium"))
                .Select(u => u.Name)
                .Take(count)
                .ToListAsync();
        }
        public async Task<User?> GetUserWithMostSubscriptionsAsync()
        {
            return await _context.Set<User>()
                .OrderByDescending(u => u.Subscriptions.Count)
                .FirstOrDefaultAsync();
        }
    }
}
