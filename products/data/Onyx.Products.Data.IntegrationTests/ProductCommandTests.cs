using Microsoft.EntityFrameworkCore;
using Onyx.Products.Data.Commands;
using Onyx.Products.Data.EF;
using Onyx.Products.Data.Interfaces;
using Onyx.Products.Domain.Models;
using Testcontainers.MsSql;

namespace Onyx.Products.Data.IntegrationTests;

public class ProductCommandTests : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();
    public Task InitializeAsync() => _msSqlContainer.StartAsync();
    public Task DisposeAsync() => _msSqlContainer.DisposeAsync().AsTask();
    
    [Fact]
    public async Task Command_Inserts_Valid_Product()
    {
        // Arrange
        ProductsContext db = new(_msSqlContainer.GetConnectionString());
        await db.Database.MigrateAsync();
        ICommand<Product> command = new ProductInsertCommand(db);
        Product product = new()
        {
            Name = "Fake Product",
            Created = new DateTime(2024, 01, 01),
            Colour = new ProductColour()
            {
                Name = "Blue",
            },
            Notes = "Some Notes",
            Price = 99.9M,
        };
         
        // Act
        Product insertedProduct = await command.Execute(product); 
         
        // Assert
        Assert.NotNull(insertedProduct);
        Assert.Equal(1, insertedProduct.Id);
    }   
}