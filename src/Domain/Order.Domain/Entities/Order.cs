namespace Order.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
