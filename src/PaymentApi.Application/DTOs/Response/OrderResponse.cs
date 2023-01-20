using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Response
{
    public class OrderResponse
    {
        [JsonPropertyName("Codigo")]
        public Guid Id { get; set; }
        [JsonPropertyName("Numero")]
        public string OrderNumber { get; set; }

        [JsonPropertyName("Dados do Vendedor")]
        public SellerResponse Seller { get; set; }

        [JsonPropertyName("DataVenda")]
        public string CreatedDate { get; set; }

        [JsonPropertyName("StatusVenda")]
        public string Status { get; set; }

        public OrderResponse(Guid id,string orderNumber, SellerResponse seller, DateTime createdDate, EOrderStatus status)
        {
            Id = id;
            Seller = seller;
            CreatedDate = createdDate.ToString("dddd, dd MMMM yyyy");
            Status = status.ToString();
            OrderNumber = orderNumber;
        }

        public static OrderResponse CovertToResponse(Order order)
        {
            return new OrderResponse
            (
                order.Id,
                order.OrderNumber,
                new SellerResponse(
                                   order.Seller.Id,
                                   order.Seller.Name,
                                   order.Seller.CPF,
                                   order.Seller.Email,
                                   order.Seller.Telefone),
                order.CreateDate.Date,
                order.Status
            )
            {

            };
        }
               
 
    }
}