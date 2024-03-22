namespace Core.Pagination;
internal interface IOrderPreset<TEntytyModel>
{
    IOrderedQueryable<TEntytyModel> Apply(IQueryable<TEntytyModel> query, bool isSorted);
}
