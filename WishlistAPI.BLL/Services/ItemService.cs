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
            var item = mapper.Map<CreateItemDto,Item>(itemDto);
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> GetItemByIdAsync(string id)
        {
            var item = await context.Items.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await context.Items
                                 .Include(i=>i.Category)
                                 .Include(i=>i.Currency).ToListAsync();
        }
    }
}
