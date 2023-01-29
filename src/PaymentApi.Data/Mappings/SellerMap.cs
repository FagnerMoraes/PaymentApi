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
            builder.ToTable("TB_SELLER");

            builder.HasData(new[]
            {
                new Seller(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857702"),"Vendedor01","11111111","teste@teste.com","123123"),
                new Seller(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857703"),"Vendedor02","11111221","teste@teste.com","123123")
            });
        }
    }
}
