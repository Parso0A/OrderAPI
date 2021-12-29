namespace Order.Domain.Contract.Models.OrderItem
{
    public class OrderItemDto
    {
        public long ProductTypeId { get; set; }

        public int Quantity { get; set; }
    }
}
