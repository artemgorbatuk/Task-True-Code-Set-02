using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Ordering;
using Core.Pagination;

namespace Core.Ordering;

/// <summary>
/// OrderPreset если используется, то после Select
/// </summary>
public static class OrderingIQueryableExtensions
{
    public static OrderingProcessor<TEntityModel> OrderPreset<TEntityModel>(this IQueryable<TEntityModel> query, string sortField, bool sortByDesc = true)
    {
        return new OrderingProcessor<TEntityModel>(query, sortField, sortByDesc);
    }

    public static OrderingProcessor<TEntityModel> OrderPreset<TEntityModel>(this IQueryable<TEntityModel> query, PaginationSet paginationSet)
    {
        bool isDesc = !string.IsNullOrEmpty(paginationSet.CollationType) &&
                            ((paginationSet.CollationType).Trim().ToLower() == "desc");

        return new OrderingProcessor<TEntityModel>(query, paginationSet.CollationName, isDesc);
    }

}