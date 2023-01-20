using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApi.Domain.Entities;

namespace PaymentApi.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUTO");

            builder.HasData(new[]
            {
                new Product(1,"Produto 01",2),
                new Product(2,"Produto 02",2)
            });
        }
    }
}