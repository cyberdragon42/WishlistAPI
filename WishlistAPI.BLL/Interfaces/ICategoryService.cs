using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<ShowCategoryDto> GetCategoryByIdAsync(string id);
        Task<IEnumerable<ShowCategoryDto>> GetCategoriesAsync();
        Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
