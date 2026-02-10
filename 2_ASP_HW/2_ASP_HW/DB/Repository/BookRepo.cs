using _2_ASP_HW.DB.models;
using Hazar_ASP_1hw.DB;
using Microsoft.EntityFrameworkCore;

namespace _2_ASP_HW.DB.services
{
    public class BookRepo
    {
        private DataContext _context;
        public BookRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context._book.ToListAsync();
        }
        public async Task<Book> GetById(int id)
        {
            return await _context._book.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(Book Book)
        {
            _context._book.Add(Book);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var Book = await GetById(id);
            if (Book != null)
            {
                _context._book.Remove(Book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Update(Book Book)
        {
            _context._book.Update(Book);
            await _context.SaveChangesAsync();
        }
    }
}
