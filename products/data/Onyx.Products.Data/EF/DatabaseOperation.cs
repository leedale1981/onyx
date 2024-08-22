using Microsoft.EntityFrameworkCore;

namespace Onyx.Products.Data.EF;

public abstract class DatabaseOperation(DbContext dbContext) : IDisposable
{
    public void Dispose()
    {
        dbContext.Database.CloseConnection();
        dbContext.Dispose();
    }
}