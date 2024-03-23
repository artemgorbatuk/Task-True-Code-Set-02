using Core.DataManipulation.Pagination;
using Core.Models;

namespace Core.Interfaces;
public interface IRepositoryUser
{
    IEnumerable<UserEntity> GetUsersBy(Guid userId, string domain, UserIncludes userIncludes);
    PaginationResult<UserEntity> GetUsersBy(string domain, UserIncludes userIncludes, PaginationSet pagination);
    IEnumerable<UserEntity> GetUsersBy(string tagValue);
}