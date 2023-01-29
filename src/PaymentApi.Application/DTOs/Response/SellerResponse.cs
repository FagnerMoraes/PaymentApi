using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Response
{
    public class SellerResponse
    {
        public Guid Id { get; set; }
        [JsonPropertyName("Nome")]
        public string Name { get; set; }

        [JsonPropertyName("CPF")]
        public string CPF { get; set; }
        
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Contato")]
        public string Telefone { get; set; }

        public SellerResponse(Guid id,string name, string cPF, string email, string telefone)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            Email = email;
            Telefone = telefone;
        }

        public static SellerResponse ConvertForResponse(Seller seller)
        {
            return new SellerResponse(
                seller.Id,
                seller.Name,
                seller.CPF,
                seller.Email,
                seller.Telefone
                );
        }

    }
}