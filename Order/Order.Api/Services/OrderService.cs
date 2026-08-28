using Order.Api.Entities;
using Order.Api.Repositories;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly BasketApiClient _basketApiClient;
        private readonly CatalogApiClient _catalogApiClient;

        public OrderService(IOrderRepository orderRepository, BasketApiClient basketApiClient, CatalogApiClient catalogApiClient)
        {
            _orderRepository = orderRepository;
            _basketApiClient = basketApiClient;
            _catalogApiClient = catalogApiClient;
        }

        public async Task<CustomerOrder> CreateOrderAsync(string username, string basketId, int deliviryMethodId, Address address)
        {

            //1. Get Basket From Basket.Api using BasketApiClient

            var basket = await _basketApiClient.GetBasketAsync(basketId);


            // 2. Get Selected Items at basket

            var orderItems = new List<OrderItem>();

            foreach(var item in basket.items)
            {
                var product = await _catalogApiClient.GetProductById(item.ProductId);

                var orderItem = new OrderItem(product.Id, product.Name, product.Price, item.Quantity);

                orderItems.Add(orderItem);
            }


            //3. Calculate SubTotal

            var subTotal = orderItems.Sum(oi => (oi.Quantiry * oi.Price));

            //4. Get Delivery Method

            var deliveryMethod = await _orderRepository.GetDeliviryMethod(deliviryMethodId);


            //5. Create Order and save it in the database

            var order = new CustomerOrder(username, orderItems, deliveryMethod, address,subTotal, "test Psyment Intent Id");


            await _orderRepository.CreateOrder(order);


            return order;

        }
    }
}
