using PaymentApi.Application.DTOs.Response;
using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Request
{
    public class CreateSaleRequest
    {
        [JsonPropertyName("DadosVenda")]
        public CreateOrderRequest OrderRequest { get; set; }

        [JsonPropertyName("ItensVenda")]
        public List<CreateOrderItemRequest>? OrderItemsSale { get; set; } = new List<CreateOrderItemRequest>();

        public CreateSaleRequest(CreateOrderRequest orderRequest)
        {
            OrderRequest = orderRequest;
        }


        public static Sale ConvertForEntity(CreateSaleRequest saleRequest)
        {

            Sale newSale = new Sale();

            newSale.OrderSale = new Order(saleRequest.OrderRequest.SellerId);

                                        
            foreach(var item in saleRequest.OrderItemsSale)
            {
                newSale.OrderItemsSale.Add(new OrderItem(default, default, item.ProductId));
            }
                
                return newSale;

        }

    }
}