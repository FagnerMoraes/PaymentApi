using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Interfaces.Services.Shared;

public interface IBaseService<TEntity> : IDisposable where TEntity : Entity
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
    Task<object> AdicionarAsync(TEntity objeto);
    Task AtualizarAsync(TEntity objeto);
    Task RemoverAsync(TEntity objeto);
    Task RemoverPorIdAsync(int id);
}

