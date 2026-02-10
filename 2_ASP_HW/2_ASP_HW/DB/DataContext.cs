using _2_ASP_HW.DB.models;
using Microsoft.EntityFrameworkCore;

namespace Hazar_ASP_1hw.DB
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        } 
        public DbSet<Book> _book;
    }
}
