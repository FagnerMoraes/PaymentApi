using PaymentApi.Domain.Entities.Shared;
using PaymentApi.Domain.Interfaces.Repositories.Shared;
using PaymentApi.Domain.Interfaces.Services.Shared;

namespace PaymentApi.Domain.Services.Shared
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> _repositoryBase;

        public BaseService(IBaseRepository<TEntity> repositoryBase) =>
            _repositoryBase = repositoryBase;

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
            await _repositoryBase.ObterTodosAsync();

        public virtual async Task<TEntity?> ObterPorIdAsync(int id) =>
            await _repositoryBase.ObterPorIdAsync(id);

        public virtual async Task<object> AdicionarAsync(TEntity objeto) =>
            await _repositoryBase.AdicionarAsync(objeto);

        public virtual async Task AtualizarAsync(TEntity objeto) =>
            await _repositoryBase.AtualizarAsync(objeto);

        public virtual async Task RemoverAsync(TEntity objeto) =>
            await _repositoryBase.RemoverAsync(objeto);

        public virtual async Task RemoverPorIdAsync(int id) =>
            await _repositoryBase.RemoverPorIdAsync(id);

        public void Dispose() =>
            _repositoryBase.Dispose();
    }
}
