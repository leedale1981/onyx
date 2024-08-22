namespace Onyx.Products.Data.Interfaces;

public interface ICommand<T> : IDisposable where T : class
{
    Task<T> Execute(T data);
}