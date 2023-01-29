
using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Interfaces.Repositories.Shared;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
{
        Task<bool> VerifyInDB(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<object> CreateAsync(TEntity objeto);
        Task<object> UpdateAsync(TEntity objeto);
        Task RemoveAsync(TEntity objeto);  
        Task RemoveByIdAsync(Guid id);
}
