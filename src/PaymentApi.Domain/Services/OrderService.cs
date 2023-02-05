
using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Enums;
using PaymentApi.Domain.Interfaces.Repositories;
using PaymentApi.Domain.Interfaces.Services;

namespace PaymentApi.Domain.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository) =>
        _orderRepository = orderRepository;

    public async Task<IEnumerable<Order>> ObterTodosAsync() =>
        await _orderRepository.ObterTodosAsync();

    public async Task<object> ObterPorIdAsync(Guid id) =>
        await _orderRepository.ObterPorIdAsync(id);

    public async Task<Guid> AdicionarAsync(Order order) =>
        await _orderRepository.AdicionarAsync(order);
                

    public async Task<object> UpdateOrderToApproved(Guid Id) {
        var order = await _orderRepository.ObterPorIdAsync(Id);
        if(order is null)
            throw new ArgumentNullException(Id.ToString(),"Venda não encontrada.");

        //verificar se tem produtos

        if ((int)order.Status != (int)EOrderStatus.AguardandoPagamento){
            throw new InvalidOperationException("Venda com status invalido para aprovacao.");
        }
        order.ApprovedPayment();
        return await _orderRepository.AtualizarAsync(order);
               
    }

    public async Task<object> UpdateOrderToCancel(Guid Id) {
        var order = await _orderRepository.ObterPorIdAsync(Id);
        if(order is null)
            throw new ArgumentNullException(Id.ToString(), "Venda não encontrada.");

        if ((int)order.Status != (int)EOrderStatus.AguardandoPagamento &&
            (int)order.Status != (int)EOrderStatus.PagamentoAprovado ){
            throw new InvalidOperationException("Venda com status invalido para cancelametos.");         
        }
        order.CancelPayment();
       return await _orderRepository.AtualizarAsync(order);
    }

    public async Task<object> UpdateOrderToSendToCarrier(Guid Id) {
        var order = await _orderRepository.ObterPorIdAsync(Id);
        if(order is null)
            throw new ArgumentNullException(Id.ToString(), "Venda não encontrada.");

        if ((int)order.Status != (int)EOrderStatus.PagamentoAprovado){
            throw new InvalidOperationException("Venda com status invalido para envio ao transporte.");         
        }
        order.SendToCarrier();
        return await _orderRepository.AtualizarAsync(order);
    }

    public async Task<object> UpdateOrderToDelivered(Guid Id) {
        var order = await _orderRepository.ObterPorIdAsync(Id);
        if(order is null)
            throw new ArgumentNullException(Id.ToString(), "Venda não encontrada.");

        if ((int)order.Status != (int)EOrderStatus.EnviadoParaTransportadora){
            throw new InvalidOperationException("Venda com status invalido para estar entregue.");         
        }
        order.Delivered();
        return await _orderRepository.AtualizarAsync(order);
    }
}
