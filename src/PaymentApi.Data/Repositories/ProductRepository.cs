using PaymentApi.Data.Context;
using PaymentApi.Data.Repositories.Shared;
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories;

namespace PaymentApi.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
