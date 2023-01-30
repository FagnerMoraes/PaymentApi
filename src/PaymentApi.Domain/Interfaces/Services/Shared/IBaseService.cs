using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Interfaces.Services.Shared;

public interface IBaseService<TEntity> where TEntity : Entity
{
    Task CreateAsync(TEntity objeto);
    void Update(TEntity objeto);
    Task RemoveByIdAsync(Guid id);
}

