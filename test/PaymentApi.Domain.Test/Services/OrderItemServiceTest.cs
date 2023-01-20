﻿using NSubstitute;
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Interfaces.Services;
using PaymentApi.Domain.Services;

namespace PaymentApi.Domain.Test.Services;

public class OrderItemServiceTest
{
    private readonly IOrderItemService _orderItemService;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly Order _order;
    private readonly Product _product;
    private readonly Seller _seller;
    private readonly OrderItem _orderItem;


    public OrderItemServiceTest()
    {
        _product = new Product(1, "Produto01", 5);

        _product = new Product(2, "Produto02", 8);

        _seller = new Seller(1, "Vendedor1", "1234", "test@test.com", "123456");

        _order = new Order(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),_seller.Id);

        _orderItem = new OrderItem(1,_order.Id,_product.Id);

        _orderItemRepository = Substitute.For<IOrderItemRepository>();

        _orderItemService = new OrderItemService(_orderItemRepository);



    }

    [Fact]
    public async Task Adicionar_item_da_venda_retorna_Id()
    {
        var id = _orderItem.Id;
        _orderItemService.AdicionarAsync(_orderItem)
                         .Returns(id);

        var OrderItemNewId = await _orderItemService.AdicionarAsync(_orderItem);

        OrderItemNewId.Should().Be(id);
    }

    [Fact]
    public async Task Adicionar_item_da_venda_com_OrderId_diferente_retorna_null()
    {
        var orderItemFake = new OrderItem(new Guid(), _product.Id);
        _orderItemService.AdicionarAsync(_orderItem)
                         .Returns(orderItemFake);

        var OrderItemNew = (OrderItem)await _orderItemService.AdicionarAsync(orderItemFake);

        OrderItemNew.Should().Be(null);
    }



}
