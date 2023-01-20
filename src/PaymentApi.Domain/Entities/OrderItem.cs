using PaymentApi.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(int id,Guid orderId, int productId)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
        }

        public OrderItem(Guid orderId, int productId)
        : this(default, orderId,productId) { }


        public Guid OrderId { get; private set; }
        public int ProductId { get; private set; }

        public virtual Order? Order { get; private set; }
        public virtual Product? Product { get; private set; }
    }
}
