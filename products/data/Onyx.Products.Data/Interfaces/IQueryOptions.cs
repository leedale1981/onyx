using System.Linq.Expressions;

namespace Onyx.Products.Data.Interfaces;

public interface IQueryOptions<T>
{
    Expression<Func<T, bool>> QueryPredicate { get; set; }
    string SortBy { get; set; }
    int Top { get; set; }
    int Skip { get; set; }
}