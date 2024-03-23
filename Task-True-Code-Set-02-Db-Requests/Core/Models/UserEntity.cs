using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class UserEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = default!;
    public string Domain { get; set; } = default!;
    public IEnumerable<UserTagEntity>? UserTags { get; set; }
}
public class UserTagEntity
{
    public Guid TagId { get; set; }

    public string Value { get; set; } = default!;

    public string Domain { get; set; } = default!;
}

public class UserIncludes
{
    public bool IsTagsIncluded { get; set; }
}