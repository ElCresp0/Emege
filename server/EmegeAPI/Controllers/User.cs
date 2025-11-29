using EmegeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmegeAPI.Controllers;

public class UserController : Controller
{
    // GET: /user/
    public UserModel getUser(string name)
    {
        // TODO: Attach a DB and create a user
        return new UserModel(id: 5, name: name);
    }
}