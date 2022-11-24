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
    public class CategoryService : ICategoryService
    {
        private readonly WishlistDbContext context;
        private readonly IMapper mapper;

        public CategoryService(WishlistDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = mapper.Map<CreateCategoryDto, Category>(categoryDto);
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ShowCategoryDto>> GetCategoriesAsync()
        {
            var categories = context.Categories.ToList();
            var categoryDtos = mapper.Map<IEnumerable<Category>, IEnumerable<ShowCategoryDto>>(categories);
            return categoryDtos;
        }

        public async Task<ShowCategoryDto> GetCategoryByIdAsync(string id)
        {
            var category = await context.Categories.FindAsync(id);
            return mapper.Map<Category, ShowCategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var category = await context.Categories.FindAsync(categoryDto.Id);
            if (category != null)
            {
                category.Description = categoryDto.Description;
                category.Name = categoryDto.Name;
                await context.SaveChangesAsync();
            }
        }
    }
}
