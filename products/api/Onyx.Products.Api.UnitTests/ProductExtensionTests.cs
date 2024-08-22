using Onyx.Products.Api.Contracts;
using Onyx.Products.Api.Extensions;
using Onyx.Products.Api.UnitTests.Fakes;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Api.UnitTests;

public class ProductExtensionTests
{
    [Fact]
    public void Product_Returns_Correct_Dto_Name()
    {
        // Arrange
        Product product = ProductFakes.GetValidProduct();

        // Act
        ProductContract dto = product.AsDto();

        // Assert
        Assert.Equal("Fake Product", dto.Name);
    }
    
    [Fact]
    public void Product_Returns_Correct_Dto_Price()
    {
        // Arrange
        Product product = ProductFakes.GetValidProduct();

        // Act
        ProductContract dto = product.AsDto();

        // Assert
        Assert.Equal(99.9M, dto.Price);
    }
    [Fact]
    public void Product_Returns_Correct_Dto_Colour()
    {
        // Arrange
        Product product = ProductFakes.GetValidProduct();

        // Act
        ProductContract dto = product.AsDto();

        // Assert
        Assert.Equal("Blue", dto.Colour);
    }
    
}