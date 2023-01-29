using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Entities
{
    public class Product : Entity
    {
        public Product(
            Guid id,
            string title,
            decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }


    }
}