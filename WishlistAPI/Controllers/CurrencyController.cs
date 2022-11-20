using Microsoft.AspNetCore.Mvc;
using WishlistAPI.BLL.Dto;
using WishlistAPI.BLL.Interfaces;
using WishlistAPI.BLL.Services;


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
        public async Task<ActionResult> GetAllCurrencies()
        {
            var currencies = await currencyService.GetCurrenciesAsync();
            if (currencies == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(currencies);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCurrency(string id)
        {
            var currency = await currencyService.GetCurrencyByIdAsync(id);
            if (currency == null)
            {
                return BadRequest();
            }
            return Ok(currency);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCurrencyDto currencyDto)
        {
            await currencyService.CreateCurrencyAsync(currencyDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit([FromBody] UpdateCurrencyDto currencyDto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await currencyService.DeleteCurrencyAsync(id);
            return Ok();
        }
    }
}
