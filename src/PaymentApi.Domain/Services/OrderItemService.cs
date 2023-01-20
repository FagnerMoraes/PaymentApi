using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Entities.Shared;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Interfaces.Repositories.Shared;
using PaymentApi.Domain.Interfaces.Services;
using PaymentApi.Domain.Services.Shared;


namespace PaymentApi.Domain.Services;

public class OrderItemService : BaseService<OrderItem>, IOrderItemService
{
    //private readonly IOrderItemRepository _orderItemRepository;
    public OrderItemService(IOrderItemRepository repositoryBase) : base(repositoryBase)
    {
    }

    //public override async Task<object> AdicionarAsync(OrderItem orderItem) =>
    //        await repositoryBase.AdicionarAsync(objeto);


}
