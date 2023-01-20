using PaymentApi.Data.Context;
using PaymentApi.Data.Repositories.Shared;
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Data.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
