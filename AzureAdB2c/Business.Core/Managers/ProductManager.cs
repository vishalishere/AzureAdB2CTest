using AzureAdB2c.Domain.Contracts.Factories;
using AzureAdB2c.Domain.Contracts.Handlers;
using AzureAdB2c.Domain.Contracts.Managers;
using AzureAdB2c.Domain.Contracts.Repositories;
using AzureAdB2c.Domain.Contracts.Validators;
using AzureAdB2c.Domain.Entities;

namespace AzureAdB2c.Business.Core.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IProductValidator _productValidator;
        private readonly IProductRepository _productRepository;
        private readonly IProductFactory _productFactory;


        public ProductManager(
            IExceptionHandler exceptionHandler,
            IProductValidator productValidator,
            IProductRepository productRepository,
            IProductFactory productFactory)
        {
            _exceptionHandler = exceptionHandler;
            _productValidator = productValidator;
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

        public Product Add(string name)
        {
            if (_productValidator.IsValidName(name) == false)
                return null;

            var product = _productFactory.Create(name);

            return _exceptionHandler.FromUnsafeFunction(() =>
                _productRepository.Create(product));
        }
    }
}
