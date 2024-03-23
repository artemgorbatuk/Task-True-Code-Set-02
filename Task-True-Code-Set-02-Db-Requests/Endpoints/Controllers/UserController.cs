using Core.Pagination;
using Microsoft.AspNetCore.Mvc;
using Services.Functionality;
using Services.Interfaces;
using Services.Models;

namespace Endpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IServiceUser _serviceUser;

    public UserController(IServiceUser serviceUser)
    {
        _serviceUser = serviceUser;
    }

    [HttpGet("GetUsers")]
    [ProducesDefaultResponseType(typeof(RequestResult<ScreenUserGet>))]
    public IActionResult GetUsers(Guid userId, string domain)
    {
        var result = _serviceUser.GetUserBy(userId, domain);

        return Ok(result);
    }

    [HttpGet("GetUsers")]
    [ProducesDefaultResponseType(typeof(RequestResult<ScreenUserGet>))]
    public IActionResult GetUsers(string domain, PaginationSet paginationSet)
    {
        var result = _serviceUser.GetUserBy(domain, paginationSet);

        return Ok(result);
    }

    [HttpGet("GetUsers")]
    [ProducesDefaultResponseType(typeof(RequestResult<ScreenUserGet>))]
    public IActionResult GetUsers(string tagValue)
    {
        var result = _serviceUser.GetUserBy(tagValue);

        return Ok(result);
    }
}