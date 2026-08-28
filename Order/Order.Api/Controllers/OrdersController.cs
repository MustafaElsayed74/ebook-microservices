using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Entities;
using Order.Api.Repositories;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        [HttpGet("username/{username}")]
        public async Task<ActionResult<IReadOnlyList<CustomerOrder>>> GetOrdersByUsername(string username)
        {
            return Ok(await _orderRepository.GetOrdersByUsername(username));

        }


        [HttpGet("id:{id}", Name = "GetOrderById")]
        public async Task<ActionResult<CustomerOrder>> GetOrderById(int id)
        {

            var order = await _orderRepository.GetOrdersById(id);

            if (order != null)
                return Ok(order);

            return NotFound($"Order with id: {id} not found");
        }


     


    }
}
