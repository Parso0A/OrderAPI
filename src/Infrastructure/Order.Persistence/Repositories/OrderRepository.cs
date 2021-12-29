namespace Order.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(OrderEntity order, CancellationToken cancellationToken)
        {
            await _dbContext.Orders.AddAsync(order, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<OrderEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // Where(...).FirstOrDefault() > FirstOrDefault(...) -- Performance-Wise
            return await _dbContext.Orders.AsNoTracking().Where(x => x.Id.Equals(id)).Include(x => x.Items).ThenInclude(x=>x.ProductType).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
