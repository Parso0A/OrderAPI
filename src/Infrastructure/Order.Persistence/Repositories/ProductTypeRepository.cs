namespace Order.Persistence.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly OrderDbContext _dbContext;

        public ProductTypeRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductType productType, CancellationToken cancellationToken = default)
        {
            await _dbContext.ProductTypes.AddAsync(productType, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductType>> GetAllAsync(CancellationToken cancellationToken)
        {
            //Since we're not modifying or deleting anything, there's no need for tracking. Better performance !
            return await _dbContext.ProductTypes.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
