using Core.Domain;
using Core.Pagination;

namespace Core.Interfaces;
public interface IRepositoryUser
{
    IEnumerable<User> GetUsersBy(Guid userId, string domain);
    IEnumerable<User> GetUsersBy(string domain, PaginationSet pagination);
    IEnumerable<User> GetUsersBy(string tagValue);
}