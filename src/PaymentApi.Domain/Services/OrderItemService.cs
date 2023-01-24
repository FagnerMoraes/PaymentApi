using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Interfaces.Services;
using PaymentApi.Domain.Services.Shared;


namespace PaymentApi.Domain.Services;

public class OrderItemService : BaseService<OrderItem>, IOrderItemService
{
    public OrderItemService(IOrderItemRepository repositoryBase) : base(repositoryBase)
    {
    }



}
