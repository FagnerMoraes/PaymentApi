using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Request
{
    public class CreateOrderItemRequest
    {
        [JsonPropertyName("Código da Venda")]
        public Guid OrderId { get; set; }
        [JsonPropertyName("Codigos de produtos")]
        public int ProductId { get; set; }

        public CreateOrderItemRequest(Guid orderId, int productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }

        public static OrderItem ConvertForEntity(Guid id,CreateOrderItemRequest orderItemRequest)
        {

            return new OrderItem(
                id,
                orderItemRequest.ProductId
                );
        }

    }
}
