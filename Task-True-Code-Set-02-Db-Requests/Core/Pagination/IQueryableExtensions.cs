using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pagination;
public static class IQueryableExtensions
{
    public static PaginationProcessor<TEntityModel> OrderBy<TEntityModel>(this IQueryable<TEntityModel> query, string sortField, bool sortByDesc)
    {
        return new PaginationProcessor<TEntityModel>(query, sortField, sortByDesc);
    }

    public static PaginationProcessor<TEntityModel> OrderBy<TEntityModel>(this IQueryable<TEntityModel> query, PaginationSet paginationSet)
    {
        bool isDesc = !string.IsNullOrEmpty(paginationSet.CollationType) &&
                            ((paginationSet.CollationType).Trim().ToLower() == "desc");

        return new PaginationProcessor<TEntityModel>(query, paginationSet.CollationName, isDesc);
    }

    public static IQueryable<TEntityModel> WhereString<TEntityModel>(this IQueryable<TEntityModel> query, string value, Func<string, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereNullableInt<TEntityModel>(this IQueryable<TEntityModel> query, int? value, Func<int, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereNullableDecimal<TEntityModel>(this IQueryable<TEntityModel> query, decimal? value, Func<decimal, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereYesNoList<TEntityModel>(this IQueryable<TEntityModel> query, List<string> yesNo, Func<List<bool>, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereYesNoString<TEntityModel>(this IQueryable<TEntityModel> query, string yesNo, Func<bool, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereDateRange<TEntityModel>(this IQueryable<TEntityModel> query, DateTime? from, DateTime? to, Func<DateTime, DateTime, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereNullableDateTime<TEntityModel>(this IQueryable<TEntityModel> query, DateTime? value, Func<DateTime, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereList<TEntityModel, TValue>(this IQueryable<TEntityModel> query, List<TValue> values, Func<List<TValue>, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static PaginationResult<TEntityModel> ToPage<TEntityModel>(this IQueryable<TEntityModel> query, PaginationSet paginationSet)
    {
        var currentPage = paginationSet.CurrentPage > 0
            ? paginationSet.CurrentPage
            : 1;

        var count = query.Count();

        var totalPages = count % paginationSet.PageSize == 0
            ? count / paginationSet.PageSize
            : count / paginationSet.PageSize + 1;

        if (currentPage > totalPages)
        {
            currentPage = 1;
        }

        var filteredResult = query
            .Skip(paginationSet.PageSize * (currentPage - 1))
            .Take(paginationSet.PageSize);

        return new PaginationResult<TEntityModel>
        {
            TotalRecords = count,
            FilteredResult = filteredResult
        };
    }
}