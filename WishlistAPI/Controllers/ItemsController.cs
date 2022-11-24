using Microsoft.AspNetCore.Mvc;
using WishlistAPI.BLL.Dto;
using WishlistAPI.BLL.Interfaces;
using WishlistAPI.Domain.Models;

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
        public async Task<ActionResult> Create([FromBody] CreateItemDto itemDto)
        {
            var item = await itemService.CreateItemAsync(itemDto);
            return Ok(item);
        }


        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] UpdateItemDto item)
        {
            await itemService.EditItemAsync(item);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await itemService.DeleteItemAsync(id);
            return Ok();
        }
    }
}
