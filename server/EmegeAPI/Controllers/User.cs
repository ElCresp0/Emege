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

    // GET: /users/{name}
    [HttpGet("/users/{name}")]
    public ActionResult getUser(string name)
    {
        UserModel? user = UserService.GetUser(name);
        return (user != null) ? Ok(user) : NotFound($"Could not find user: {name}");
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