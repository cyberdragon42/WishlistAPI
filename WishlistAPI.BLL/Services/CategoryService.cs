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
    public class CategoryService: ICategoryService
    {
        private readonly WishlistDbContext context;
        private readonly IMapper mapper;

        public CategoryService(WishlistDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = mapper.Map<CreateCategoryDto, Category>(categoryDto);
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
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

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = context.Categories;
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            var category = await context.Categories.FindAsync(id);
            return category;
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
