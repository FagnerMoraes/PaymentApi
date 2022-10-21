using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Domain.Entities
{
    public class Product
    {
        public Product( string title, decimal price)
        {
            Title = title;
            Price = price;
        }
        public Product(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
    }
}
