using PaymentApi.Domain.Entities;
using PaymentApi.Domain.Interfaces.Repositories.Shared;
using PaymentApi.Domain.Interfaces.Services;
using PaymentApi.Domain.Services.Shared;


namespace PaymentApi.Domain.Services;

public class SellerService : BaseService<Seller>, ISellerService
{
    public SellerService(IBaseRepository<Seller> repositoryBase) : base(repositoryBase)
    {
    }
}

