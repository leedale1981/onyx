using System.Linq.Expressions;
using Onyx.Products.Data.Interfaces;

namespace Onyx.Products.Data.Queries;

public class QueryOptions<T> : IQueryOptions<T>
{
    public Expression<Func<T, bool>> QueryPredicate { get; set; } = entity => true;
    public string SortBy { get; set; }
    public int Top { get; set; }
    public int Skip { get; set; }
}