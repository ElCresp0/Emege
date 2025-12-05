using EmegeAPI.Models;

namespace EmegeAPI.Services;

public class UserService
{
    // 
    // This is an imitation of a usable service. TODO: attach a DB to work with actual data records.
    // 

    private static string imagesDir = "Emeges";

    public static UserModel? GetUser(string name)
    {
        if (name == "Greg")
        {
            return null;
        }
        else
        {
            return new UserModel(Guid.NewGuid(), name, new DateOnly(2025, 1, 1));
        }
    }
    public static UserModel? CreateUser(string name)
    {
        if (name == "Greg")
        {
            Guid user_id = Guid.NewGuid();
            return new UserModel(user_id, name, new DateOnly());
        }
        else
        {
            return null;
        }
    }

    public static int? GetUserImageCount(string name)
    {
        // root images dir check
        if (Directory.Exists(imagesDir) == false)
        {
            return null;
        }

        // user images dir check
        string userImagesDir = Path.Join(imagesDir, name);
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
}