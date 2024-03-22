using System.ComponentModel.DataAnnotations;

namespace Core.Domain;
public class Tag
{
    public Guid TagId { get; set; }

    [Required]
    public string Value { get; set; } = default!;

    [Required]
    public string Domain { get; set; } = default!;

    public List<TagToUser>? TagToUsers { get; set; }
}
