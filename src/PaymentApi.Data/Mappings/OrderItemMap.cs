using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApi.Domain.Entities;

namespace PaymentApi.Data.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("TB_ORDERITEM");

            //builder.HasData(new[]
            //{
            //    new OrderItem(1,new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),1),
            //    new OrderItem(2,new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),2)
            //});
        }
    }
}
