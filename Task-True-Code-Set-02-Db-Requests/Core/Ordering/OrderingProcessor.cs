using System.Linq.Expressions;

namespace Core.Ordering;
public class OrderingProcessor<TEntityModel>
{
    private readonly string _collationName;
    private readonly bool _iscollationTypeDesc;
    private readonly IQueryable<TEntityModel> _query;
    private IOrderPreset<TEntityModel> _orderPreset;

    public OrderingProcessor(IQueryable<TEntityModel> query, string collationName, bool _iscollationTypeDesc)
    {
        _query = query;
        _collationName = collationName;
        this._iscollationTypeDesc = _iscollationTypeDesc;
    }

    /// <summary>
    /// Используется после OrderPreset
    /// Указываем колонки которые будут иметь возможность сортировки
    /// </summary>
    public OrderingProcessor<TEntityModel> FieldCanBeOrdered<TEntityField>(string field, Expression<Func<TEntityModel, TEntityField>> expression)
    {
        if (string.Equals(field, _collationName, StringComparison.OrdinalIgnoreCase))
        {
            _orderPreset = new OrderPreset<TEntityModel, TEntityField>(expression);
        }

        return this;
    }

    /// <summary>
    /// Используется после FieldCanBeOrdered
    /// Указываем колонку по которой будет сортировка по умолчанию
    /// </summary>
    public OrderingProcessor<TEntityModel> DefaultOrderColumn<TEntityField>(Expression<Func<TEntityModel, TEntityField>> expression)
    {
        if (_orderPreset == null)
        {
            _orderPreset = new OrderPreset<TEntityModel, TEntityField>(expression);
        }

        return this;
    }

    /// <summary>
    /// Используется если использовались 
    /// Применяем OrderPreset
    /// </summary>
    public IQueryable<TEntityModel> ApplyOrderPreset()
    {
        if (_orderPreset == null)
        {
            return _query;
        }

        return _orderPreset.ApplyOrderPreset(_query, _iscollationTypeDesc);
    }
}