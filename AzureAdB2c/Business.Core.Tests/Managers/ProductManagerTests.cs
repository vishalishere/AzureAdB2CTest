using Microsoft.VisualStudio.TestTools.UnitTesting;
using AzureAdB2c.Business.Core.Managers;
using AzureAdB2c.CrossCutting.TestHelpers;
using AzureAdB2c.Domain.Contracts.Validators;
using Should;

namespace Business.Core.Tests.Managers
{
    [TestClass]
    public class ProductManagerTests : TestsFor<ProductManager>
    {
        [TestMethod, TestCategory(ProductTestCategories.Validators)]
        public void Add_ProductNameIsInvalid_ResultIsNull()
        {
            // Arrange
            GetMockFor<IProductValidator>()
                .Setup(o => o.IsValidName(AnyKindOf.String)).Returns(false);

            // Act            
            var result = Instance.Add("coca-cola");

            // Assert   
            result.ShouldBeNull();
        }
    }
}
