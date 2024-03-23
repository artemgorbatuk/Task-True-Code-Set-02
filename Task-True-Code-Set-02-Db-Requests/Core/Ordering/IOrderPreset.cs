namespace Core.Ordering;
internal interface IOrderPreset<TEntytyModel>
{
    IOrderedQueryable<TEntytyModel> ApplyOrderPreset(IQueryable<TEntytyModel> query, bool isSorted);
}
