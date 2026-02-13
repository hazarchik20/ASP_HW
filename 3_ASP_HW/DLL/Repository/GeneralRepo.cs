using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class GeneralRepo<T> where T : class
    {
        public DataContext _context;
        public GeneralRepo(DataContext context) 
        {
            _context = context;
        }
        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            var keyProperty = entityType!
                .FindPrimaryKey()!
                .Properties
                .First();

            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(e =>
                EF.Property<int>(e, keyProperty.Name) == id
            );
        }
        public async Task<T[]> GetAllAsync()
        {
            return await _context.Set<T>().ToArrayAsync();
        }

        public async Task<T> AddAsync(T element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();
            return element;
        }
        public async Task<T> UpdateAsync(T element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();
            return element;
        }
        public async Task DeleteAsync(int id)
        {
            var element = await GetByIdAsync(id);
            if (element == null) return;
            _context.Remove(element);
            await _context.SaveChangesAsync();
        }
    }
}
