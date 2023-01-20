﻿using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Services.Shared;

namespace PaymentApi.Domain.Interfaces.Services;
public interface IOrderService {

    Task<object> UpdateOrderToApproved(Guid Id);
    Task<object> UpdateOrderToCancel(Guid Id);
    Task<object> UpdateOrderToSendToCarrier(Guid Id);
    Task<object> UpdateOrderToDelivered(Guid Id);

    Task<IEnumerable<Order>> ObterTodosAsync();
    Task<object> ObterPorIdAsync(Guid id);
    Task<object> AdicionarAsync(Order order);


}
