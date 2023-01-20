using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Response;
public class SaleResponse
{
    [JsonPropertyName("Dados da Venda")]
    public OrderResponse? OrderSale { get; set; }
    [JsonPropertyName("Lista de Produtos")]
    public List<OrderItemResponse>? OrderItemsSale { get; set; } = new List<OrderItemResponse>();


    public static SaleResponse CovertToResponse(Sale sale)
    {
        SaleResponse saleResponse = new SaleResponse();

        saleResponse.OrderSale = new OrderResponse(
                        sale.OrderSale.Id,
                        sale.OrderSale.OrderNumber,
                        new SellerResponse(
                                sale.OrderSale.Seller.Id,
                                sale.OrderSale.Seller.Name,
                                sale.OrderSale.Seller.CPF,
                                sale.OrderSale.Seller.Email,
                                sale.OrderSale.Seller.Telefone
                            ),
                        sale.OrderSale.CreateDate,
                        sale.OrderSale.Status);

            foreach (var item in sale.OrderItemsSale)
            {
            saleResponse.OrderItemsSale.Add(new OrderItemResponse(
                                        item.Id,
                                        item.OrderId,    
                                        new ProductResponse(item.Product.Title,item.Product.Price)
                                        ));
            }

        

        return saleResponse;


    }
}

