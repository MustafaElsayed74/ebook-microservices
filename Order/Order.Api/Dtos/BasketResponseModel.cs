namespace Order.Api.Dtos
{
    public class BasketResponseModel
    {
        public string Username { get; set; }
        public ICollection<ItemsResponseModel> items { get; set; } 
    }
}
