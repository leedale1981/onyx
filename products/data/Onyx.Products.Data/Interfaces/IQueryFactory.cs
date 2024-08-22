namespace Onyx.Products.Data.Interfaces;

public interface IQueryFactory<T> where T : class
{
    IQuery<T> CreateQuery();
}