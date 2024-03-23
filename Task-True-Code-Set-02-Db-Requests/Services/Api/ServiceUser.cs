using Core.DataManipulation.Pagination;
using Core.Interfaces;
using Core.Models;
using Services.Functionality;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Api;
public class ServiceUser : IServiceUser
{
    private readonly IRepositoryUser _repositoryUser;

    public ServiceUser(IRepositoryUser repositoryUser)
    {
        _repositoryUser = repositoryUser;
    }

    public RequestResult<ScreenUserGet> GetUserBy(Guid userId, string domain)
    {
        // Здесть мне нравиться использовать паттерн Step-By-Step :
        // - валидация входящих параметров
        // - проверка доступов
        // - попытка получить данные из кэша
        // итд
        // Здесь можно увидеть пример https://github.com/danielgerlag/workflow-core

        try
        {
            var userIncludes = new UserIncludes() { IsTagsIncluded = true };

            var users = _repositoryUser.GetUsersBy(userId, domain, userIncludes);

            return new RequestResult<ScreenUserGet>()
            {
                Data = new ScreenUserGet() { Users = users },
                MessageType = MessageType.Success,
                MessageText = "Users were successfully obtained."
            };
        }
        catch (Exception exception)
        {
            return new RequestResult<ScreenUserGet>()
            {
                MessageType = MessageType.Error,
                MessageText = $"Exception : {exception}"
            };
        }
    }

    public RequestResult<ScreenUserPaginatedGet> GetUserBy(string domain, PaginationSet paginationSet)
    {
        try
        {
            var userIncludes = new UserIncludes() { IsTagsIncluded = true };

            var paginatedUsers = _repositoryUser.GetUsersBy(domain, userIncludes, paginationSet);

            return new RequestResult<ScreenUserPaginatedGet>()
            {
                Data = new ScreenUserPaginatedGet() { PaginatedUsers = paginatedUsers },
                MessageType = MessageType.Success,
                MessageText = "Users were successfully obtained."
            };
        }
        catch (Exception exception)
        {
            return new RequestResult<ScreenUserPaginatedGet>()
            {
                MessageType = MessageType.Error,
                MessageText = $"Exception : {exception}"
            };
        }
    }

    public RequestResult<ScreenUserGet> GetUserBy(string tagValue)
    {
        var users = _repositoryUser.GetUsersBy(tagValue);

        return new RequestResult<ScreenUserGet>()
        {
            Data = new ScreenUserGet() { Users = users },
            MessageType = MessageType.Success,
            MessageText = "Users were successfully obtained."
        };
    }
}