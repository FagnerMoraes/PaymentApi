using PaymentApi.Domain.Interfaces.Services;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Services;
using PaymentApi.Domain.Enums;

namespace PaymentApi.Domain.Test.Services
{
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly Order _order;
        
        
        public OrderServiceTest()
        {            
            var seller = new Seller(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),"Vendedor1","1234","test@test.com","123456");
            
            _order = new Order(
                seller.Id
            );

            _orderRepository = Substitute.For<IOrderRepository>();

            _orderService = new OrderService(_orderRepository);

        }

        [Fact]
        public async Task Alterar_Status_da_Venda_para_Pagamento_Aprovado_Deve_Alterar()
        {
            var segundostatus = EOrderStatus.PagamentoAprovado;

            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            var UpdatedOrder = (Order)await _orderService.UpdateOrderToApproved(_order.Id);

            UpdatedOrder.Status.Should().Be(segundostatus);

        }

        [Fact]
        public async Task Alterar_Status_da_Venda_para_Pagamento_Cancelado_Deve_Alterar()
        {
            var segundostatus = EOrderStatus.Cancelada;

            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            var OrderUpdated = (Order)await _orderService.UpdateOrderToCancel(_order.Id);

            OrderUpdated.Status.Should().Be(segundostatus);

        }

        [Fact]
        public async Task Alterar_Status_da_Venda_de_Pagamento_Aprovado_para_Enviado_Para_Transporte_Deve_Alterar()
        {
            var terceiroStatus = EOrderStatus.EnviadoParaTransportadora;

            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.ApprovedPayment();

            var OrderUpdated = (Order)await _orderService.UpdateOrderToSendToCarrier(_order.Id);
            

            OrderUpdated.Status.Should().Be(terceiroStatus);
        }

        [Fact]
        public async Task Alterar_Status_da_Venda_de_Pagamento_Aprovado_para_Pagamentoo_Cancelado_Deve_Alterar()
        {
            var terceiroStatus = EOrderStatus.Cancelada;

            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.ApprovedPayment();

            var OrderUpdated = (Order)await _orderService.UpdateOrderToCancel(_order.Id);


            OrderUpdated.Status.Should().Be(terceiroStatus);
        }

        [Fact]
        public async Task Alterar_Status_da_Venda_de_Enviado_Para_Transporte_para_Entregue_Deve_Alterar()
        {
            var terceiroStatus = EOrderStatus.Entregue;

            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.SendToCarrier();

            var OrderUpdated = (Order)await _orderService.UpdateOrderToDelivered(_order.Id);


            OrderUpdated.Status.Should().Be(terceiroStatus);
        }

        [Fact]
        public async Task Alterar_Status_da_Venda_de_Pagamento_Cancelado_para_Enviado_Para_Transporte_deve_Retornar_InvalidOperationException()
        {
            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.CancelPayment();

            Func<Task> act = async() => await _orderService.UpdateOrderToSendToCarrier(_order.Id);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task Alterar_Status_da_Venda_de_Pagamento_Cancelado_para_Entregue_deve_Retornar_InvalidOperationException()
        {
            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.CancelPayment();

            Func<Task> act = async () => await _orderService.UpdateOrderToDelivered(_order.Id);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }


        [Fact]
        public async Task Alterar_Status_da_Venda_de_Pagamento_Aprovado_para_Entregue_deve_Retornar_InvalidOperationException()
        {
            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.ApprovedPayment();

            Func<Task> act = async () => await _orderService.UpdateOrderToDelivered(_order.Id);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task Alterar_Status_da_Venda_de_Enviado_para_Transportadora_para_Pagamento_Cancelado_deve_Retornar_InvalidOperationException()
        {
            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.SendToCarrier();

            Func<Task> act = async () => await _orderService.UpdateOrderToCancel(_order.Id);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task Alterar_Status_da_Venda_Passando_Venda_Invalida_deve_Retornar_ArgumentNullException()
        {
            _orderRepository.ObterPorIdAsync(_order.Id)
                .Returns(_order);
            _orderRepository.AtualizarAsync(_order).Returns(_order);

            _order.ApprovedPayment();

            Func<Task> act = async () => await _orderService.UpdateOrderToCancel(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"));

            await act.Should().ThrowAsync<ArgumentNullException>();
        }


        [Fact]
        public async Task Adicionar_Ordem_Deve_Retornar_Id()
        {
            // Arrange
            var id = 1;
            _orderRepository.AdicionarAsync(_order)
                .Returns(id);

            // Act
            var OrderNewId = await _orderService.AdicionarAsync(_order);

            // Assert
            OrderNewId.Should().Be(id);
        }

        [Fact]
        public async Task Adicionar_Ordem_Deve_Sem_Vendedor_retorna_Null()
        {
            // Arrange
            var orderFake = new Order(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857706"));
            _orderRepository.AdicionarAsync(_order)
                .Returns(orderFake);

            // Act

            var OrderNew = await _orderService.AdicionarAsync(orderFake);


            // Assert
            OrderNew.Should().Be(null);
        }



    }
}