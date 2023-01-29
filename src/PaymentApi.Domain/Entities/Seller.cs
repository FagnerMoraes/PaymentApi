using PaymentApi.Domain.Entities.Shared;

namespace PaymentApi.Domain.Entities
{
    public class Seller : Entity
    {
        public Seller(Guid id,string name, string cPF, string email, string telefone)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            Email = email;
            Telefone = telefone;
        }

        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public ICollection<Order>? Orders { get; private set; }

    }
}