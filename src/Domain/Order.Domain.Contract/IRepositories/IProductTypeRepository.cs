namespace Order.Domain.Contract.IRepositories
{
    public interface IProductTypeRepository
    {
        Task AddAsync(ProductType productType, CancellationToken cancellationToken = default);
        Task<List<ProductType>> GetAllAsync(CancellationToken cancellationToken);
    }
}
