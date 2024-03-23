using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataManipulation;

/// <summary>
/// Расширения для IQueryable Where 
/// Методы выполняют следующую функциию 
/// Когда несколько нескольк фильтров приходит с UI
/// Все фильтры должны быть применены.
/// </summary>
public static class WhereIQueryableExtensions
{
    public static IQueryable<TEntityModel> WhereString<TEntityModel>(this IQueryable<TEntityModel> query, string value, Func<string, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return isRequired ? query.Where(x => false) : query;
        }

        return query.Where(expression(value.Trim()));
    }

    public static IQueryable<TEntityModel> WhereIntNullable<TEntityModel>(this IQueryable<TEntityModel> query, int? value, Func<int, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereDecimalNullable<TEntityModel>(this IQueryable<TEntityModel> query, decimal? value, Func<decimal, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
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

    public static IQueryable<TEntityModel> WhereDateTimeNullable<TEntityModel>(this IQueryable<TEntityModel> query, DateTime? value, Func<DateTime, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }

    public static IQueryable<TEntityModel> WhereList<TEntityModel, TValue>(this IQueryable<TEntityModel> query, List<TValue> values, Func<List<TValue>, Expression<Func<TEntityModel, bool>>> expression, bool isRequired = false)
    {
        throw new NotImplementedException();
    }
}
