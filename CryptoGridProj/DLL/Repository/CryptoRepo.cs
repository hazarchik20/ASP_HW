using DLL.Interfaces;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class CryptoRepo : ICryptoRepo
    {
        CryptoContext _context;
        public CryptoRepo(CryptoContext context) 
        {
            _context = context;
        }
        public async Task<Crypto> AddCryptoAsync(Crypto crypto)
        {
            _context.Cryptos.Add(crypto);
            await _context.SaveChangesAsync();
            return crypto;
        }

        public async Task DeleteCryptoAsync(int id)
        {
            var crypto = await GetCryptoByIdAsync(id);
            _context.Cryptos.Remove(crypto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Crypto>> GetAllCryptosAsync()
        {
            var cryptos = await _context.Cryptos.ToListAsync();
            return cryptos;
        }

        public async Task<Crypto> GetCryptoByIdAsync(int id)
        {
            var crypto = await _context.Cryptos.FirstOrDefaultAsync(c => c.Id == id);
            return crypto;
        }

        public async Task<Crypto> UpdateCryptoAsync(Crypto crypto)
        {
            _context.Cryptos.Update(crypto);
            await _context.SaveChangesAsync();
            return crypto;
        }
    }
}
