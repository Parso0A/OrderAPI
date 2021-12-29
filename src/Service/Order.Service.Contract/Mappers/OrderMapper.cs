
namespace Order.Service.Contract.Mappers
{
    public static class OrderMapper
    {
        public static Domain.Entities.Order ToEntity(this CreateOrderRequest source)
        {
            return source is null ? null :
                new Domain.Entities.Order
                {
                    Items = source.Items?.Select(x => new OrderItem
                    {
                        ProductTypeId = x.ProductTypeId,
                        Quantity = x.Quantity,
                    }).ToList() ?? new List<OrderItem>(),
                    CreatedDate = source.CreatedDate,
                };
        }

        public static OrderDto ToDto(this Domain.Entities.Order source)
        {
            return source is null ? null :
                new OrderDto
                {
                    CreatedDate = source.CreatedDate,
                    Id = source.Id,
                    Items = source.Items?.Select(x=> new OrderItemDto
                    {
                        ProductTypeId=x.ProductTypeId,
                        Quantity =x.Quantity,
                    }).ToList() ?? new List<OrderItemDto>()
                };
        }
    }
}
