using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]/products")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger<Product> _logger;

        public CatalogController(IProductsRepository productsRepository, ILogger<Product> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAll()
        {
            var products = await _productsRepository.GetAllProductsAsync();
            return Ok(products);
        }



        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetById(string id)
        {

            var product = await _productsRepository.GetByIdAsync(id);

            if (product == null)
            {

                _logger.LogError($"Product with id: {id} nor found");
                return NotFound();
            }
            return Ok(product);

        }


        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IReadOnlyList<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IReadOnlyList<Product>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetByCategory(string category)
        {
            var products = await _productsRepository.GetByCategoryAsync(category);
            return Ok(products);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(typeof(IReadOnlyList<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IReadOnlyList<Product>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetByName(string name)
        {
            var products = await _productsRepository.GetByNameAsync(name);
            return Ok(products);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            await _productsRepository.CreateProductAsync(product);

            return CreatedAtRoute("GetProduct", new { Id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> Update([FromBody] Product product)
        {

            return Ok(await _productsRepository.UpdateProductAsync(product));
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> Delete(string id)
        {

            return Ok(await _productsRepository.DeleteProductAsync(id));
        }
    }
}
