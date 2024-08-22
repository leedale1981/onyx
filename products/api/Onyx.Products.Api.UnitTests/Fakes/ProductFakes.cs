using Onyx.Products.Domain.Models;

namespace Onyx.Products.Api.UnitTests.Fakes;

public static class ProductFakes
{
    public static Product GetValidProduct()
    {
        return new()
        {
            Id = 1,
            Name = "Fake Product",
            Created = new DateTime(2024, 01, 01),
            Colour = new ProductColour()
            {
                Id = 1,
                Name = "Blue",
            },
            Notes = "Some Notes",
            Price = 99.9M,
        };
    }
}