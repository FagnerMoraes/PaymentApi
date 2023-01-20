
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Domain.Entities.Shared;
using PaymentApi.Domain.Enums;

namespace PaymentApi.Domain.Entities
{
    public class Order
    {

        public Order(int sellerId)
        {
            Id = Guid.NewGuid();
            SellerId = sellerId;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            OrderNumber = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        }

        public Order(Guid id, int sellerId) : this(sellerId)
        {
            Id = id;
            SellerId = sellerId;
        }

        public Guid Id { get; private set; }
        public string OrderNumber { get; private set; }
        public int SellerId {get; private set;}
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public Seller? Seller { get; private set; }


        public void ApprovedPayment()
        {
            Status = EOrderStatus.PagamentoAprovado;
            UpdateDate = DateTime.Now;
        }

        public void CancelPayment(){
            Status = EOrderStatus.Cancelada;
            UpdateDate = DateTime.Now; 
        }

        public void SendToCarrier(){
            Status = EOrderStatus.EnviadoParaTransportadora;
            UpdateDate = DateTime.Now; 
        }

        public void Delivered(){
            Status = EOrderStatus.Entregue;
            UpdateDate = DateTime.Now; 
        }


    }

        
}