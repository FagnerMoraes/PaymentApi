
using PaymentApi.Domain.Entities;
using System.Text.Json.Serialization;

namespace PaymentApi.Application.DTOs.Response
{
    public class OrderItemResponse
    {
        public OrderItemResponse(Guid id,Guid orderId,ProductResponse product)
        {
            Id = id;
            OrderId = orderId;
            Product = product;
        }

        [JsonPropertyName("CodigoOrdemItem ")]
        public Guid Id { get; set; }
        [JsonPropertyName("CodigoOrdem")]
        public Guid OrderId { get;set;}
        [JsonPropertyName("Produto")]
        public ProductResponse Product { get; set; }


        public static OrderItemResponse CovertToResponse(OrderItem orderItem)
        {   
            return new OrderItemResponse(
                                orderItem.Id,
                                orderItem.OrderId,
                                new ProductResponse(orderItem.Product.Title, orderItem.Product.Price)                          
                                );
        }



    }
}
