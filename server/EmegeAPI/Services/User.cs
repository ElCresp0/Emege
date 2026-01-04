using EmegeAPI.Models;
using EmegeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmegeAPI.Services;

public class UserService
{
    // 
    // This is an imitation of a usable service. TODO: attach a DB to work with actual data records.
    // 

    private string imagesDir = "Data/Emeges";

    private readonly ApplicationDBContext _context;
    private readonly ILogger _logger;

    public UserService(ApplicationDBContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<UserModel?> GetUser(string name)
    {
        try
        {
            UserModel user = await _context.Users.Where(u => u.Name == name).SingleAsync();
            return user;
        }
        catch // SingleAsync throws errors if none or many records match the query
        {
            return null; // null; // NotFound
        }

    }
    public async Task<UserModel?> CreateUser(UserModel user)
    {
        bool userExists = await _context.Users.Where(u => u.Name == user.Name).AnyAsync();
        if (userExists)
        {
            return null;
        }
        else
        {
            // create emeges dir
            // root images dir check
            if (Directory.Exists(imagesDir) == false)
            {
                _logger.LogError($"Root image directory {imagesDir} doesn't exist.");
                return null;
            }

            string userImagesDir = Path.Join(imagesDir, user.Id.ToString());
            if (Directory.Exists(userImagesDir) == true)
            {
                _logger.LogError($"User image directory {userImagesDir} shouldn't exist before CreateUser() call.");
                return null;
            }

            Directory.CreateDirectory(userImagesDir);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }

    public async Task<int?> GetUserImageCount(string name)
    {
        // root images dir check
        if (Directory.Exists(imagesDir) == false)
        {
            return null;
        }

        UserModel? user = await GetUser(name);
        if (user == null)
        {
            return null;
        }

        // user images dir check
        string userImagesDir = Path.Join(imagesDir, user.Id.ToString());
        // user image dir exists => Ok
        if (Directory.Exists(userImagesDir))
        {
            return Directory.GetFiles(userImagesDir, """.+\.png""").Count();
        }
        else
        {
            // TODO error handling

            return null;
            // no user image dir, no user => NotFound

            // no user image dir, user exists => Error

        }
    }

    // TODO: PUT user (update name, bio)
    // TODO: DELETE user
}