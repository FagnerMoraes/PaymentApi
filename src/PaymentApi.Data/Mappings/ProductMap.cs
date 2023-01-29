using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApi.Domain.Entities;

namespace PaymentApi.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUCT");

            builder.HasData(new[]
            {
                new Product(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),"Produto 01",2),
                new Product(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857708"),"Produto 02",2)
            });

            builder.Property(p => p.Title)
                .HasColumnName("COL_TITLE_PRODUCT")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(p => p.Price)
                .HasColumnName("COL_PRICE_PRODUCT")
                .HasColumnType("MONEY")
                .IsRequired();

        }
    }
}