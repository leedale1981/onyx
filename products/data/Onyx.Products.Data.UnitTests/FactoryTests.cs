using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Onyx.Products.Data.Commands;
using Onyx.Products.Data.Factories;
using Onyx.Products.Data.Interfaces;
using Onyx.Products.Data.Queries;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Data.UnitTests;

public class FactoryTests
{
    [Fact]
    public void ProductQueryFactory_CreateQuery_Returns_ProductQuery()
    {
        // Arrange
        Mock<ILogger<ProductCommandQueryFactory>> logger = new();
        IConfigurationRoot config = GetConfig();
        ProductCommandQueryFactory factory = new(logger.Object, config);

        // Act
        IQuery<Product> result = factory.CreateQuery();

        // Assert
        Assert.IsType<ProductQuery>(result);
    }
    
    [Fact]
    public void ProductQueryFactory_CreateInsertCommand_Returns_ProductInsertCommand()
    {
        // Arrange
        Mock<ILogger<ProductCommandQueryFactory>> logger = new();
        IConfigurationRoot config = GetConfig();
        ProductCommandQueryFactory factory = new(logger.Object, config);

        // Act
        ICommand<Product> result = factory.CreateInsertCommand();

        // Assert
        Assert.IsType<ProductInsertCommand>(result);
    }

    private static IConfigurationRoot GetConfig()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", false)
            .Build();
    }
}