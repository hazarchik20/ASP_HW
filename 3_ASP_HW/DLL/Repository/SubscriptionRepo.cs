using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class SubscriptionRepo: GeneralRepo<Subscription>
    {
        private DataContext _context;
        public SubscriptionRepo(DataContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<List<Subscription>> GetEndedFreeSubscriptionsAsync()
        {
            return await _context.Set<Subscription>()
                .Where(s => s.Type == "Free" && s.ExpirationDate < DateTime.Now)
                .ToListAsync();
        }
        
        public async Task<Dictionary<string, int>> GetSubscriptionCountByTypeAsync()
        {
            return await _context.Set<Subscription>()
                .GroupBy(s => s.Type)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Type, x => x.Count);
        }
        
        public async Task<List<Subscription>> GetSubscriptionsAboveAveragePriceAsync()
        {
            var averagePrice = await _context.Set<Subscription>().AverageAsync(s => s.Price);
            return await _context.Set<Subscription>()
                .Where(s => s.Price > averagePrice)
                .ToListAsync();
        }

    }
}
