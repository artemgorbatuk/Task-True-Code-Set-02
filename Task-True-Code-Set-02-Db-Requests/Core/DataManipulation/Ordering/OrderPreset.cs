﻿using System.Linq.Expressions;

namespace Core.DataManipulation.Ordering;
internal class OrderPreset<TEntytyModel, TEntityField> : IOrderPreset<TEntytyModel>
{
    private readonly Expression<Func<TEntytyModel, TEntityField>> _expression;
    private readonly IOrderPreset<TEntytyModel>? _orderPreset;

    public OrderPreset(Expression<Func<TEntytyModel, TEntityField>> expression, IOrderPreset<TEntytyModel>? orderPreset = null)
    {
        _expression = expression;
        _orderPreset = orderPreset;
    }

    public IOrderedQueryable<TEntytyModel> ApplyOrderPreset(IQueryable<TEntytyModel> query, bool isDesc)
    {
        if (_orderPreset == null)
        {
            return isDesc ? query.OrderByDescending(_expression) : query.OrderBy(_expression);
        }

        var orderedQuery = _orderPreset.ApplyOrderPreset(query, isDesc);

        return isDesc ? orderedQuery.ThenByDescending(_expression) : orderedQuery.ThenBy(_expression);
    }
}
