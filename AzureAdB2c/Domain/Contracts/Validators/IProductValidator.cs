using AzureAdB2c.Domain.Entities;
namespace AzureAdB2c.Domain.Contracts.Validators
{
    public interface IProductValidator : IValidator<Product>
    {
        bool IsValidName(string name);
    }
}
