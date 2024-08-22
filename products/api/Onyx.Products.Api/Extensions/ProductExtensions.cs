using Onyx.Products.Api.Contracts;
using Onyx.Products.Domain.Models;

namespace Onyx.Products.Api.Extensions;

public static class ProductExtensions
{
    public static ProductContract AsDto(this Product product)
    {
        return new()
        {
            Id = product.Id,
            Name = product.Name,
            Created = product.Created,
            Colour = product.Colour.Name,
            Price = product.Price,
        };
    }
}