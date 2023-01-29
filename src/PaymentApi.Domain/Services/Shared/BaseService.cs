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

        public virtual async Task<object> CreateAsync(TEntity objeto) =>
            await _repositoryBase.CreateAsync(objeto);

        public virtual async Task UpdateAsync(TEntity objeto) =>
            await _repositoryBase.UpdateAsync(objeto);

        public virtual async Task RemoveByIdAsync(Guid id) =>
            await _repositoryBase.RemoveByIdAsync(id);

        public void Dispose() =>
            _repositoryBase.Dispose();
    }
}
