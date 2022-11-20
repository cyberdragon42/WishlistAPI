using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.BLL.Interfaces;
using WishlistAPI.DAL.Context;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly WishlistDbContext context;
        private readonly IMapper mapper;

        public CurrencyService(WishlistDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task CreateCurrencyAsync(CreateCurrencyDto currencyDto)
        {
            var currency = mapper.Map<CreateCurrencyDto, Currency>(currencyDto);
            if (currency != null)
            {
                await context.Currencies.AddAsync(currency);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteCurrencyAsync(string id)
        {
            var currency = await context.Currencies.FindAsync(id);
            if (currency != null)
            {
                context.Currencies.Remove(currency);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            var currencies = context.Currencies;
            return currencies;
        }

        public async Task<Currency> GetCurrencyByIdAsync(string id)
        {
            var currency = await context.Currencies.FindAsync(id);
            return currency;
        }

        public async Task UpdateCurrencyAsync(UpdateCurrencyDto currencyDto)
        {
            var currency = await context.Currencies.FindAsync(currencyDto.Id);
            if (currency != null)
            {
                currency.Code = currencyDto.Code;
                currency.Name = currencyDto.Name;
                currency.DollarCoefficient = currencyDto.DollarCoefficient;
                await context.SaveChangesAsync();
            }
        }
    }
}
