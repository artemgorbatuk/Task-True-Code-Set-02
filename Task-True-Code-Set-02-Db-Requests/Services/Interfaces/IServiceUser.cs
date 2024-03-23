using Core.Models;
using Core.Pagination;
using Services.Functionality;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces;
public interface IServiceUser
{
    RequestResult<ScreenUserGet> GetUserBy(Guid userId, string domain);

    RequestResult<ScreenUserPaginatedGet> GetUserBy(string domain, PaginationSet paginationSet);

    RequestResult<ScreenUserGet> GetUserBy(string tagValue);
}
