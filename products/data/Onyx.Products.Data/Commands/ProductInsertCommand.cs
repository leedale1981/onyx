using Microsoft.EntityFrameworkCore;
using Onyx.Products.Data.EF;
using Onyx.Products.Data.Interfaces;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Data.Commands;

public class ProductInsertCommand(DbContext dbContext) : DatabaseOperation(dbContext), ICommand<Product>
{
    public int Id { get; set; }
    
    public async Task<Product> Execute(Product data)
    {
        dbContext.Add(data);
        await dbContext.SaveChangesAsync();
        return data;
    }
}