using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class ItemService : IItemService
    {
        private readonly WishlistDbContext context;
        private readonly IMapper mapper;

        public ItemService(WishlistDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Item> CreateItemAsync(CreateItemDto itemDto)
        {
            var item = mapper.Map<CreateItemDto, Item>(itemDto);
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(string id)
        {
            var item = await context.Items.FindAsync(id);
            if (item != null)
            {
                context.Items.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditItemAsync(UpdateItemDto itemDto)
        {
            var item = await context.Items.FindAsync(itemDto.Id);
            if (item != null)
            {
                item.Name = itemDto.Name;
                item.Description = itemDto.Description;
                item.CategoryId = itemDto.CategoryId;
                item.Price = itemDto.Price;
                item.ImageLink = itemDto.ImageLink;
                item.CurrencyId = itemDto.CurrencyId;
                await context.SaveChangesAsync();
            }
        }

        public async Task<ShowItemDto> GetItemByIdAsync(string id)
        {
            var item = await context.Items
                .Include(i => i.Category)
                .Include(i => i.Currency)
                .Where(i => i.Id == id).FirstOrDefaultAsync();

            var itemDto = mapper.Map<Item, ShowItemDto>(item);
            return itemDto;
        }

        public async Task<IEnumerable<ShowItemDto>> GetItemsAsync()
        {
            var items = await context.Items
                .Include(i => i.Category)
                .Include(i => i.Currency)
                .ToListAsync();

            var itemsDto = mapper.Map<IEnumerable<Item>, IEnumerable<ShowItemDto>>(items);
            return itemsDto;
        }
    }
}
