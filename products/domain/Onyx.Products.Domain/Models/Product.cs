namespace Onyx.Products.Domain.Models;

public class Product
{
    public long Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTime Created { get; init; }
    public ProductColour Colour { get; set; }
    public string Notes { get; set; }
}