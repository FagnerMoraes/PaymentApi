using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PaymentApi.Domain.Entities;

namespace PaymentApi.Application.DTOs.Request
{
    public class CreateOrderRequest
    {
        [JsonPropertyName("Codigo do Vendedor")]
        public int SellerId { get; set; }


        public CreateOrderRequest(int sellerId)
        {
            SellerId = sellerId;      
        }


        public static Order ConvertForEntity(CreateOrderRequest orderRequest){
            return new Order(
                orderRequest.SellerId                          
            );
        }
    }
       
}