using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Data.Mappings
{
    public class SellerMap : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("TB_VENDEDOR");

            builder.HasData(new[]
            {
                new Seller(1,"Vendedor01","11111111","teste@teste.com","123123"),
                new Seller(2,"Vendedor02","11111221","teste@teste.com","123123")
            });
        }
    }
}
