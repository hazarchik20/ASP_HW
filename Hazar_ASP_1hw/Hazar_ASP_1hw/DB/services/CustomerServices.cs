using Hazar_ASP_1hw.DB.models;
using Microsoft.EntityFrameworkCore;

namespace Hazar_ASP_1hw.DB.services
{
    public class CustomerServices
    {
        private DataContext _context;
        public CustomerServices(DataContext context) {
            _context = context;
        }

        public async Task<List<Customer>> GetAll(int? year = 1800)
        {
            return await _context._customers.OrderBy(c=>c.Name).Where(c=> c.Year > year).ToListAsync();
        }
        public async Task<Customer> GetById(int id)
        {
            return await _context._customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<string>> GetAllUniqueName()
        {
            //var allCustomer = await GetAll();
            //List<string> currentCustomerNames = new();

            //for (int i = 0; i < allCustomer.Count; i++)
            //{
            //    if (!currentCustomerNames.Contains(allCustomer[i].Name))
            //    {
            //        currentCustomerNames.Add(allCustomer[i].Name);
            //    }
            //}

            //return currentCustomerNames;

            // ЦЕ Я ПИСАВ САМ

            return await _context._customers
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
            // А ТУТ Я ПІШОВ ГУГЛИТИ ЯК ПЕРЕВІРИТИ НА УНІКАЛЬНІСТЬ ПО МІЙ ПІДХІД НЕ РУЛЬНО ДУЖЕ ВЕЛКИЙ І НЕ ЧИТАБЕЛЬНИЙ

        }

        public async Task Add(Customer customer)
        {
            _context._customers.Add(customer);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id )
        {
            var customer = await GetById(id);
            if (customer != null)
            {
                _context._customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Update(Customer customer)
        {
            _context._customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateYear(int id,int year)
        {
            var customer = await GetById(id);
            if (customer != null)
            {
                customer.Year = year;
                await _context.SaveChangesAsync();
            }
        }
        

    }
}
