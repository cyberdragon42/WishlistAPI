using Microsoft.AspNetCore.Mvc;
using WishlistAPI.BLL.Dto;
using WishlistAPI.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<ActionResult> Post([FromBody] CreateCategoryDto categoryDto)
        {
            await categoryService.CreateCategoryAsync(categoryDto);
            return Ok();
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
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
