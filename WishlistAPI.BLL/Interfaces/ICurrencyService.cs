using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Interfaces
{
    public interface ICurrencyService
    {
        Task CreateCurrencyAsync(CreateCurrencyDto currencyDto);
        Task<Currency> GetCurrencyByIdAsync(string id);
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task UpdateCurrencyAsync(UpdateCurrencyDto currencyDto);
        Task DeleteCurrencyAsync(string id);
    }
}
