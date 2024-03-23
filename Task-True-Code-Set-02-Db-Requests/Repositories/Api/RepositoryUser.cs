using Core.DataManipulation;
using Core.DataManipulation.Pagination;
using Core.Interfaces;
using Core.Models;
using Datasource.Contexts;
using Datasource.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Api;
public class RepositoryUser : IRepositoryUser
{
    private readonly IServiceScopeFactory scopeFactory;

    public RepositoryUser(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    public IEnumerable<UserEntity> GetUsersBy(Guid userId, string domain, UserIncludes userIncludes)
    {
        using var scope = scopeFactory.CreateAsyncScope();

        using var context = scope.ServiceProvider.GetRequiredService<DbContextTrueCode>();

        var query = context.Users
            .AsNoTracking()
            .Where(p => p.UserId == userId 
                     && p.Domain == domain);
     
        if(userIncludes.IsTagsIncluded)
        {
            query.Include(p => p.TagToUsers);
        }

        var entities = query.Select(p => new UserEntity()
        {
            UserId = p.UserId,
            Name = p.Name,
            Domain = p.Domain,
            UserTags = getUserTags(p),
        });

        return entities;
    }

    public PaginationResult<UserEntity> GetUsersBy(string domain, UserIncludes userIncludes, PaginationSet paginationSet)
    {
        using var scope = scopeFactory.CreateAsyncScope();

        var context = scope.ServiceProvider.GetRequiredService<DbContextTrueCode>();

        var query = context.Users
            .AsNoTracking()
            .Where(p => p.Domain == domain);

        if (userIncludes.IsTagsIncluded)
        {
            query.Include(p => p.TagToUsers);
        }

        var entities = query.Select(p => new UserEntity()
        {
            UserId = p.UserId,
            Name = p.Name,
            Domain = p.Domain,
            UserTags = getUserTags(p),
        });

        return entities.ToPage(paginationSet);

    }

    public IEnumerable<UserEntity> GetUsersBy(string tagValue)
    {
        using var scope = scopeFactory.CreateAsyncScope();

        var context = scope.ServiceProvider.GetRequiredService<DbContextTrueCode>();

        var query = context.Users
            .AsNoTracking()
            .WhereString(tagValue, value => model => model.TagToUsers != null 
                && model.TagToUsers.Any(p => p.Tag != null && p.Tag.Value.Contains(value)));

        var entities = query.Select(p => new UserEntity()
        {
            UserId = p.UserId,
            Name = p.Name,
            Domain = p.Domain,
        });

        return entities;
    }

    private Func<User, IEnumerable<UserTagEntity>> getUserTags = (user) =>
    {
        var userTags = user.TagToUsers != null
            ? user.TagToUsers
                .Select(p => p.Tag!)
                .Select(p => new UserTagEntity()
                {
                    TagId = p.TagId, Value = p.Value, Domain = p.Domain
                })
            : new List<UserTagEntity>();

        return userTags;
    };
}
