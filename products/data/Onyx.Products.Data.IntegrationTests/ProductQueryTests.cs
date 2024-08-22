using Microsoft.EntityFrameworkCore;
using Onyx.Products.Data.EF;
using Onyx.Products.Data.Interfaces;
using Onyx.Products.Data.Queries;
using Onyx.Products.Domain.Models;
using Testcontainers.MsSql;

namespace Onyx.Products.Data.IntegrationTests;

public class ProductQueryTests : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();
    public Task InitializeAsync() => _msSqlContainer.StartAsync();
    public Task DisposeAsync() => _msSqlContainer.DisposeAsync().AsTask();
    
    [Fact]
    public async Task Query_Returns_Valid_Product()
    {
         // Arrange
         ProductsContext db = new(_msSqlContainer.GetConnectionString());
         await db.Database.MigrateAsync();
         await _msSqlContainer.ExecScriptAsync("INSERT INTO ProductColour VALUES('Blue')");
         await _msSqlContainer.ExecScriptAsync("INSERT INTO Products VALUES('Test product', 99.9, datefromparts(2024, 01, 01), 1, '')");
         IQuery<Product> query = new ProductQuery(db);
         long id = 1;
         
         // Act
         IEnumerable<Product> products = await query.Execute(new QueryOptions<Product>()
         {
             QueryPredicate = (product) => product.Id == id
         });

         Product? product = products.FirstOrDefault();
         
         // Assert
         Assert.NotNull(product);
         Assert.NotNull(product.Colour);
    }
}