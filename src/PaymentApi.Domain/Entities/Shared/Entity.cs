namespace PaymentApi.Domain.Entities.Shared
{
    public class Entity
    {
        public Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; protected set;}
    }
}