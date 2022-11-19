using Microsoft.AspNetCore.Mvc;
using WishlistAPI.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishlistAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
