namespace Order.Domain.Entities.BaseInfo
{
    public class ProductType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int StackSize { get; set; }
        
        public decimal Width { get; set; }
        [JsonIgnore]

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
