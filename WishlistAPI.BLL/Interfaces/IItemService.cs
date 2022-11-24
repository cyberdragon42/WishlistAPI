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
        Task<IEnumerable<ShowItemDto>> GetItemsAsync();
        Task<ShowItemDto> GetItemByIdAsync(string id);
        Task EditItemAsync(UpdateItemDto itemDto);
        Task DeleteItemAsync(string id);
    }
}
