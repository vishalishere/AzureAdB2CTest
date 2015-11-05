using AzureAdB2c.Domain.Contracts.Validators;
using AzureAdB2c.Domain.Entities;

namespace AzureAdB2c.Business.Core.Validators
{
    public class ProductValidator : IProductValidator
    {
        public bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            return true;
        }

        public bool IsValid(Product entity)
        {
            if (entity == null)
                return false;
            if (entity.Price != null && !IsValidName(entity.Name))
                return false;

            return true;
        }
    }
}
