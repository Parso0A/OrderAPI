namespace Order.Service.Contract.IServices
{
    public interface IProductTypeService
    {
        Task<List<ProductType>> GetAllAsync(CancellationToken cancellationToken);
    }
}
