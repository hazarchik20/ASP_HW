using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface ICryptoRepo
    {
            Task<IEnumerable<Crypto>> GetAllCryptosAsync();
            Task<Crypto> GetCryptoByIdAsync(int id);
            Task<Crypto> AddCryptoAsync(Crypto crypto);
            Task<Crypto> UpdateCryptoAsync(Crypto crypto);
            Task DeleteCryptoAsync(int id);
    }
}
