using AzureAdB2c.Domain.Entities;

namespace AzureAdB2c.Domain.Contracts.Factories
{
    public interface IProductFactory
    {
        Product Create(string name);
    }
}
