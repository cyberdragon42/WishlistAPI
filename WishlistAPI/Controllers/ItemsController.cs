using Microsoft.AspNetCore.Mvc;
using WishlistAPI.BLL.Dto;
using WishlistAPI.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishlistAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService itemService;
        
        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItems()
        {
            var items = await itemService.GetItemsAsync();
            return Ok(items);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(string id)
        {
            var item = await itemService.GetItemByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] CreateItemDto itemDto)
        {
            var item = await itemService.CreateItemAsync(itemDto);
            return Ok(item);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
