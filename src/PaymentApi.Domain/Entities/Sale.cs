using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Domain.Entities
{
    public class Sale
    {
        public Order OrderSale { get; set; }
        public ICollection<OrderItem> OrderItemsSale { get; set; }
    }
}
