namespace Onyx.Products.Api.Contracts;

public class ProductContract
{
    public long Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTime Created { get; init; }
    public string Colour { get; set; }
}