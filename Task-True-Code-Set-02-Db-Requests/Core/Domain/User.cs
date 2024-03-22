﻿using System.ComponentModel.DataAnnotations;

namespace Core.Domain;
public class User
{
    public Guid UserId { get; set; }

    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public string Domain { get; set; } = default!;

    public List<TagToUser>? TagToUsers { get; set; }
}
