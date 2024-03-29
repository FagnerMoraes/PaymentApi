using Microsoft.EntityFrameworkCore;
using PaymentApi.Data.Context;
using PaymentApi.Data.Repositories.Shared;
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Entities.Shared;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Interfaces.Repositories.Shared;

namespace PaymentApi.Data.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext Context;
        private readonly IBaseRepository<Order> _baseRepository;


        public OrderRepository(DataContext dataContext, IBaseRepository<Order> baseRepository) 
        {
            _baseRepository = baseRepository;
            Context = dataContext;
        }


        public async Task<Sale?> GetByIdAsync(Guid id)
        {
            Sale sale = new()
            {
                OrderSale = await Context.Orders.Include(o => o.Seller).AsNoTracking().FirstOrDefaultAsync(o => o.Id.Equals(id)),
                
                OrderItemsSale = await Context.OrderItems
                                       .Include(o => o.Product)
                                       .Where(o => o.OrderId.Equals(id)).ToListAsync()
        };
            return  sale;
        }

        public async Task<object> AtualizarAsync(Order order)
        {
            Context.Entry(order).Property(p => p.Status).IsModified = true;
            Context.Entry(order).Property(p => p.UpdateDate).IsModified = true;
            await Context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> ObterPorIdAsync(Guid id)
        {
            await _baseRepository.GetAllAsync();
            return await Context.Set<Order>().Include(x => x.Seller).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<Order>> ObterTodosAsync() =>
        await Context.Set<Order>()
            .AsNoTracking()
        .ToListAsync();

        public async Task<Guid> AdicionarAsync(Order order)
        {
            await Context.AddAsync(order);
            return order.Id;
        }



    }
}