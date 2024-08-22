using Microsoft.EntityFrameworkCore;
using Onyx.Products.Data.EF;
using Onyx.Products.Data.Interfaces;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Data.Queries;

public class ProductQuery(DbContext dbContext) : DatabaseOperation(dbContext), IQuery<Product>
{
    public int Id { get; set; }
    
    public async Task<IEnumerable<Product>> Execute(IQueryOptions<Product> query)
    {
        return await Task.FromResult(((ProductsContext)dbContext)
            .Products
            .Include(p => p.Colour)
            .Where(query.QueryPredicate));
    }
}