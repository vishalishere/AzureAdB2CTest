using AzureAdB2c.Domain.Entities;

namespace AzureAdB2c.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Product Create(Product demo);
    }
}
