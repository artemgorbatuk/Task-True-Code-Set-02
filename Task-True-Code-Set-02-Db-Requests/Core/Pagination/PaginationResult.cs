using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pagination;

[Serializable]
public class PaginationResult<TDomainModel>
{
    public int TotalRecords { get; set; }
    public IEnumerable<TDomainModel> FilteredResult { get; set; }
}
