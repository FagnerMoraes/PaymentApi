using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories.Shared;

namespace PaymentApi.Domain.Interfaces.Repositories;

public interface IOrderRepository{

    Task<object> AtualizarAsync(Order order);

    Task<Order?> ObterPorIdAsync(Guid id);

    Task<Sale?> GetByIdAsync(Guid id);

    Task<IEnumerable<Order>> ObterTodosAsync();

    Task<Guid> AdicionarAsync(Order order);

}

