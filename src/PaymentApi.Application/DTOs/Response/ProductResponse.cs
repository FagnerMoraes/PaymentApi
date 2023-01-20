using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Response
{
    public class ProductResponse
    {
        public ProductResponse(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
        [JsonPropertyName("Nome")]
        public string Title { get; set; }

        [JsonPropertyName("Preco")]
        public decimal Price { get; set; }

        public static ProductResponse ConvertCovertToResponse(Product product)
        {
            return new ProductResponse(product.Title,product.Price);
        }
    }
}