using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Enums;

namespace PaymentApi.Domain.Test.Entities;

public class OrderTest
{
    private readonly Order _order;
    private readonly Seller _seller;

     public OrderTest()
    {
        _seller = new Seller(1,"Vendedor1","1234","test@test.com","123456");
        
        _order = new Order( _seller.Id );
    }

    [Fact]
    public void Data_Atualizacao_deve_ser_diferente_de_data_de_criacao_ao_alterar_status()
    {
        var PrimeiraDataAtualizacao = _order.UpdateDate;
        _order.ApprovedPayment();
        var SegundaDataAtualizacao = _order.UpdateDate;

        SegundaDataAtualizacao.Should().NotBe(PrimeiraDataAtualizacao);
    }

    [Fact]
    public void Ao_Criar_Venda_Status_Deve_Ser_Aguardando_Pagamento()
    {
        _order.Status.Should().Be(EOrderStatus.AguardandoPagamento);
    }

    [Fact]
    public void Data_Uma_venda_deve_Aprovar_Pagamento()
    {
        _order.ApprovedPayment();
        _order.Status.Should().Be(EOrderStatus.PagamentoAprovado);            
    }

    [Fact]
    public void Data_Uma_venda_deve_Cancelar_Pagamento()
    {
        _order.CancelPayment();
        _order.Status.Should().Be(EOrderStatus.Cancelada);
    }

    [Fact]
    public void Data_Uma_venda_deve_Enviar_Para_transportadora()
    {
        _order.SendToCarrier();
        _order.Status.Should().Be(EOrderStatus.EnviadoParaTransportadora);
    }

    [Fact]
    public void Data_Uma_venda_deve_Ser_Entegue()
    {
        _order.Delivered();
        _order.Status.Should().Be(EOrderStatus.Entregue);
    }
}