using AzureAdB2c.Domain.Entities;
namespace AzureAdB2c.Domain.Contracts.Managers
{
    public interface IProductManager
    {
        Product Add(string name);
    }
}