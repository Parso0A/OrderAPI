using Order.Domain.Entities.BaseInfo;

namespace Order.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Guid OrderId { get; set; }

        public long ProductTypeId { get; set; }

        public virtual Order Order { get; set; }

        public virtual ProductType ProductType { get; set; }

        public decimal CalculateConsumedPackageWidth()
        {
            if(Quantity == 0 || ProductType is null)
            {
                return 0;
            }

            return Quantity <= ProductType.StackSize ? ProductType.Width : (Math.Floor((decimal)Quantity / ProductType.StackSize) + Quantity % ProductType.StackSize) * ProductType.Width;
        }
    }
}
