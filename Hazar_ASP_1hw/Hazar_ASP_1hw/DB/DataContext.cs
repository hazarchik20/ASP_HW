using Hazar_ASP_1hw.DB.models;
using Microsoft.EntityFrameworkCore;

namespace Hazar_ASP_1hw.DB
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        } 
        public DbSet<Customer> _customers;
    }
}
