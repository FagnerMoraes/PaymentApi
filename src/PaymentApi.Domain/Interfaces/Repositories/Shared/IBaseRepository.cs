using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Interfaces.Repositories.Shared;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
{
        Task<bool> VerifyInDB(int id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<TEntity?> ObterPorIdAsync(int id);
        Task<object> AdicionarAsync(TEntity objeto);
        Task<object> AtualizarAsync(TEntity objeto);
        Task RemoverAsync(TEntity objeto);  
        Task RemoverPorIdAsync(int id);
}
