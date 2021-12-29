namespace Order.Domain.Contract.IRepositories
{
    public interface IOrderRepository
    {
        Task AddAsync(OrderEntity order, CancellationToken cancellationToken);
        Task<OrderEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
