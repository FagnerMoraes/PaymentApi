using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
