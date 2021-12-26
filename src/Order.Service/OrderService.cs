namespace Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IValidator<CreateOrderRequest> _validator;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IValidator<CreateOrderRequest> validator,
                            IOrderRepository orderRepository)
        {
            _validator = validator;
            _orderRepository = orderRepository;
        }

        public async Task<Guid> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            if (request is null || !(await _validator.ValidateAsync(request, cancellationToken)).IsValid)
            {
                return Guid.Empty;
            }

            request.CreatedDate = DateTime.Now;

            var entity = request.ToEntity();

            await _orderRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }

        public async Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new ArgumentException("Empty Identifier");
            }

            var entity = await _orderRepository.GetByIdAsync(id, cancellationToken);

            var toReturn = entity.ToDto();

            toReturn.RequiredBinWidth = CalculateRequiredBinWidth(entity);

            return toReturn;
        }

        private decimal CalculateRequiredBinWidth(OrderEntity order)
        {
            if (order.Items?.Any() ?? false)
            {
                var requiredBinWidth = 0M;

                order.Items.ToList().ForEach(item =>
                {
                    requiredBinWidth += item.CalculateConsumedPackageWidth();
                });

                return requiredBinWidth * 10;
            }

            return 0;
        }
    }
}
