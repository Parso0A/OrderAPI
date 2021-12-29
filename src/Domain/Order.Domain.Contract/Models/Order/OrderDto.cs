namespace Order.Domain.Contract.Models.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public decimal RequiredBinWidth { get; set; }
    }
}
