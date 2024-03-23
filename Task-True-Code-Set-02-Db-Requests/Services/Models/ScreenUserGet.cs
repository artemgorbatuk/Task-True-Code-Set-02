using Core.DataManipulation.Pagination;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models;
public class ScreenUserGet
{
    public IEnumerable<UserEntity> Users { get; set; }
}
public class ScreenUserPaginatedGet
{
    public PaginationResult<UserEntity> PaginatedUsers { get; set; }
}