using Microsoft.AspNetCore.Mvc;
using WishlistAPI.BLL.Dto;
using WishlistAPI.BLL.Interfaces;


namespace WishlistAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(categories);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(string id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto categoryDto)
        {
            await categoryService.CreateCategoryAsync(categoryDto);
            return Ok();
        }


        [HttpPut("{id}")]
        public void Edit([FromBody] UpdateCategoryDto categoryDto)
        {

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
