using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Interfaces.Services.Shared;

public interface IBaseService<TEntity> : IDisposable where TEntity : Entity
{
    Task<object> CreateAsync(TEntity objeto);
    Task UpdateAsync(TEntity objeto);
    Task RemoveByIdAsync(int id);
}

