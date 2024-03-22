using System.Linq.Expressions;

namespace Core.Pagination;
public class PaginationProcessor<TEntityModel>
{
    private readonly IQueryable<TEntityModel> _query;
    private readonly string _collationName;
    private readonly bool _isSortedByDesc;
    private IOrderPreset<TEntityModel> _orderPreset;

    public PaginationProcessor(IQueryable<TEntityModel> query, string collationName, bool isSortedByDesc)
    {
        _query = query;
        _collationName = collationName;
        _isSortedByDesc = isSortedByDesc;
    }

    public PaginationProcessor<TEntityModel> Field<TEntityField>(string field, Expression<Func<TEntityModel, TEntityField>> expression)
    {
        if (string.Equals(field, _collationName, StringComparison.OrdinalIgnoreCase))
        {
            _orderPreset = new OrderPreset<TEntityModel,TEntityField>(expression);
        }

        return this;
    }

    public PaginationProcessor<TEntityModel> Default<TEntityField>(Expression<Func<TEntityModel, TEntityField>> expression)
    {
        if (_orderPreset == null)
        {
            _orderPreset = new OrderPreset<TEntityModel,TEntityField>(expression);
        }

        return this;
    }

    public IQueryable<TEntityModel> Apply()
    {
        if (_orderPreset == null)
        {
            return _query;
        }

        return _orderPreset.Apply(_query, _isSortedByDesc);
    }
}