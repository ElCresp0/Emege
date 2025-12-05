using EmegeAPI.Models;
using EmegeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmegeAPI.Controllers;

public class UserController : Controller
{
    // 
    // This class defines routes and endpoints regarding application users.
    // Actual endpoint logic is implemented in a corresponding UserService class.
    // TODO: enhance swagger documentation
    // 

    private readonly ILogger _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    // GET: /users/{name}
    [HttpGet("/users/{name}")]
    public ActionResult getUser(string name)
    {
        // Log
        _logger.LogInformation($"GET user: {name}");

        UserModel? user = UserService.GetUser(name);
        return (user != null) ? Ok(user) : NotFound($"Could not find user: {name}");
    }

    // GET: /users/{name}/images/count
    [HttpGet("/users/{name}/images/count")]
    public ActionResult getUserImageCount(string name)
    {
        // Log
        _logger.LogDebug($"GET user image count: {name}");

        int? userImageCount = UserService.GetUserImageCount(name);

        return (userImageCount != null) ? Ok(userImageCount) : NotFound($"Could not find user's image dir: {name}");
    }

    // POST: /users/register
    [HttpPost("/users/register")]
    public ActionResult registerUser(string name)
    {
        UserModel? user = UserService.CreateUser(name);
        return (user != null) ? Created($"/users/{name}", user) :
            BadRequest($"Registration unsuccessful, wrong name: {name}");
    }
}