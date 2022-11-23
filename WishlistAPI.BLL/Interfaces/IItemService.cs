using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(CreateItemDto itemDto);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemByIdAsync(string id);
    }
}
