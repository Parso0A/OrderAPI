namespace Order.Service.Contract.IServices
{
    public interface IOrderService
    {
        Task<Guid> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken);
        Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
