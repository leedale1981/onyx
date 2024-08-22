using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Onyx.Products.Data.Commands;
using Onyx.Products.Data.EF;
using Onyx.Products.Data.Interfaces;
using Onyx.Products.Data.Queries;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Data.Factories;

public class ProductCommandQueryFactory(ILogger<ProductCommandQueryFactory> logger, IConfigurationRoot config) : 
    IQueryFactory<Product>, IInsertCommandFactory<Product>
{
    public IQuery<Product> CreateQuery()
    {
        logger.LogInformation("Creating new Product query");
        return new ProductQuery(new ProductsContext(config.GetConnectionString("Products")));
    }

    public ICommand<Product> CreateInsertCommand()
    {
        logger.LogInformation("Creating new Product insert command");
        return new ProductInsertCommand(new ProductsContext(config.GetConnectionString("Products")));
    }
}