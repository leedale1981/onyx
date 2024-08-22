using Microsoft.EntityFrameworkCore;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Data.EF;

public class ProductsContext(string connectionString = "Data Source=D:\\src\\onyx\\products\\data\\products") : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Id).UseIdentityColumn();
        modelBuilder.Entity<ProductColour>().HasKey(pc => pc.Id);
        modelBuilder.Entity<ProductColour>().Property(pc => pc.Id).UseIdentityColumn();
    }
}