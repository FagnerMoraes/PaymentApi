using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApi.Domain.Entities;

namespace PaymentApi.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("TB_ORDER");

            //builder.HasData(new[]
            //{
            //    new Order(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),1)
            //});
        }
    }
}
