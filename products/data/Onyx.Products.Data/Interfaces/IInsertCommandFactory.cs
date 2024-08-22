namespace Onyx.Products.Data.Interfaces;

public interface IInsertCommandFactory<T> where T : class
{
    ICommand<T> CreateInsertCommand();
}