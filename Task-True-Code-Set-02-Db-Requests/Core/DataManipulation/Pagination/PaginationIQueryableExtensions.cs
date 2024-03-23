using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataManipulation.Pagination;

public static class PaginationIQueryableExtensions
{
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