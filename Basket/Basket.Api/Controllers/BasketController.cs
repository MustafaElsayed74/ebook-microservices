using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string username)
        {
            return Ok(await _basketRepository.GetBasketAsync(username));

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateBasket([FromBody] CustomerBasket basket)
        {
            return Ok(await _basketRepository.UpdateBasketAsnyc(basket));
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteBasket(string username) {
            return Ok(await _basketRepository.DeleteBasketAsync(username));
        }
    }
}
