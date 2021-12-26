namespace Order.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<List<ProductType>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _productTypeRepository.GetAllAsync(cancellationToken);
        }
    }
}
