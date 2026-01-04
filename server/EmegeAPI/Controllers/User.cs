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
    private readonly UserService _userService;

    public UserController(ILogger<UserController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService; // TODO: is 
    }

    // GET: /users/{name}
    [HttpGet("/users/{name}")]
    public async Task<ActionResult> getUser(string name)
    {
        // Log
        _logger.LogInformation($"GET user: {name}");

        UserModel? user = await _userService.GetUser(name);
        return (user != null) ? Ok(user) : NotFound($"Could not find user: {name}");
    }

    // GET: /users/{name}/images/count
    [HttpGet("/users/{name}/images/count")]
    public async Task<ActionResult> getUserImageCountAsync(string name)
    {
        // Log
        _logger.LogDebug($"GET user image count: {name}");

        int? userImageCount = await _userService.GetUserImageCount(name);

        return (userImageCount != null) ? Ok(userImageCount) : NotFound($"Could not find user's image dir: {name}");
    }

    // // PUT: /users/{name}/image?name,file
    // [HttpPut("/users/{userName}/image")]
    // public ActionResult uploadImage(string userName, string imageName, IFormFile imageFile)
    // {
    //     // flow:
    //     // CREATE: upload(name, file), guid=UserService.upload(name, file) -> guid=TransientImageRepoService.upload(name, file), DBService.upload(name, metadata)
    //     // READ: getImage(uName, iName), File=UserService.getImage(uName, iName) -> Emege=DBService.fetchImage(uName, iName), Emege.File=TransientImageRepoService.readImage(Emege.guid)
    //     // UPDATE: updateImage(uName, iName, file), Emege=UserService.uploadImage(uName, iName) -> Emege=DBService.updateImage(uName, iName), iRepoService.updateImage(Emege, file)
    //     // DELETE: deleteImage(uName, iName), result=UserService.deleteImage(uN, iN) -> Emege = DBService.rmImage(uN, iN), result = iRepoService.deleteImage(Emege)

    //     // Log
    //     _logger.LogDebug($"PUT user: {userName} image: {imageName}");

    //     Guid? id = _userService.uploadImage(userName, imageName, imageFile);

    //     return (userImageCount != null) ? Ok(userImageCount) : NotFound($"Could not find user's image dir: {name}");
    // }

    // POST: /users/register
    [HttpPost("/users/register")]
    public async Task<ActionResult> registerUserAsync(string name)
    {
        UserModel? user = await _userService.CreateUser(new UserModel(name));
        return (user != null) ? Created($"/users/{name}", user) :
            BadRequest($"Registration unsuccessful, wrong name: {name}");
    }
}