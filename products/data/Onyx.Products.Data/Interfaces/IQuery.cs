namespace Onyx.Products.Data.Interfaces;

public interface IQuery<T> : IDisposable where T : class
{
    Task<IEnumerable<T>> Execute(IQueryOptions<T> query);
}