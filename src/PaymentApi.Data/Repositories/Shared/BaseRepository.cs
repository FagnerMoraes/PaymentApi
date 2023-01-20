using PaymentApi.Data.Context;
using PaymentApi.Domain.Entities.Shared;
using PaymentApi.Domain.Interfaces.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace PaymentApi.Data.Repositories.Shared
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext Context;

    public BaseRepository(DataContext dataContext) =>
        Context = dataContext;

    public virtual async Task<bool> VerifyInDB(int id)
    
            => await Context.Set<TEntity>().AnyAsync(x => x.Id == id);
    

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
        await Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    public virtual async Task<TEntity?> ObterPorIdAsync(int id) =>
        await Context.Set<TEntity>().FindAsync(id);

    public virtual async Task<object> AdicionarAsync(TEntity objeto)
    {
        Context.Add(objeto);
        await Context.SaveChangesAsync();
        return objeto.Id;
    }

    public virtual async Task<object> AtualizarAsync(TEntity objeto)
    {
        Context.Entry(objeto).State = EntityState.Modified;
        await Context.SaveChangesAsync();
            return objeto.Id;
    }
    
    public virtual async Task RemoverAsync(TEntity objeto)
    {
        Context.Set<TEntity>().Remove(objeto);
        await Context.SaveChangesAsync();

    }

    public virtual async Task RemoverPorIdAsync(int id)
    {
        var objeto = await ObterPorIdAsync(id);
        if (objeto == null)
            throw new Exception("O registro não existe na base de dados.");
        await RemoverAsync(objeto);
    }

    public void Dispose() =>
        Context.Dispose();
    }
}