## Задача

 - выбрать пользователя (с его тегами) по его Id и Domain
 - выбрать всех пользователей (с их тегами) одного Domain, используя pagination
 - выбрать всех пользователей по значению тега (которые имеют данный тег) и Domain

## Приложение должно

 - быть реализовано на базе консоли (не ASP.NET Core)
 - Использовать .NET 5 или выше
 - Использовать EF API
 - Использовать стандартный Dependency Injection контейнер (IServiceProvider)

## Entity Framework Models

``` csharp

public class User
{
    public Guid UserId { get; set; }

    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public string Domain { get; set; } = default!;

    public List<TagToUser>? TagToUsers { get; set; }
}

public class TagToUser
{
    [Key]
    public Guid EntityId { get; set; }
    
    [Required]
    public Guid UserId { get; set; }

    public User? User { get; set; }
    
    [Required]
    public Guid TagId { get; set; }

    public Tag? Tag { get; set; }
}

public class Tag
{
    public Guid TagId { get; set; }

    [Required]
    public string Value { get; set; } = default!;

    [Required]
    public string Domain { get; set; } = default!;

    public List<TagToUser>? TagToUsers { get; set; }
}

```
