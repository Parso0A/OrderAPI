namespace Order.Domain.Contract.Models.Order
{
    public class CreateOrderRequest
    {
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
