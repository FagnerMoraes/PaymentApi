using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace PaymentApi.Data.Test.Repositories;

public class OrderRepositoryTests
{
    private readonly IOrderRepository _orderRepository;
    private readonly Order _order;
    private readonly Seller _seller;



    public OrderRepositoryTests()
    {
        _seller = new Seller(1, "Vendedor1", "1234", "test@test.com", "123456");

        _order = new Order(
            new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),
            _seller.Id
        );

        _orderRepository = Substitute.For<IOrderRepository>();

    }


    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);

        var id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
        var order = await _orderRepository.ObterPorIdAsync(id);

        order.Id.Should().Be(id);
    }

}
