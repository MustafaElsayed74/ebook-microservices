using Basket.Api.Entities;
using Basket.Api.Models;
using Basket.Api.Repositories;
using Basket.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly CatalogApiClient _catalogApiClient;

        public BasketController(CatalogApiClient catalogApiClien, IBasketService basketService)
        {
            _catalogApiClient = catalogApiClien;
            _basketService = basketService;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string username)
        {
            return Ok(await _basketService.GetBasketAsync(username));

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateBasket([FromBody] BasketRequest basket)
        {
           
            return Ok(await _basketService.UpdateBasketAsnyc(basket));
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteBasket(string username) {
            return Ok(await _basketService.DeleteBasketAsync(username));
        }
    }
}
