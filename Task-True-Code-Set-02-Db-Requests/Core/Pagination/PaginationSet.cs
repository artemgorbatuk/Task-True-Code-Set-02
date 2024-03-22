namespace Core.Pagination;
public class PaginationSet
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public string CollationName { get; set; } = default!;
    public string CollationType { get; set; } = default!;
}