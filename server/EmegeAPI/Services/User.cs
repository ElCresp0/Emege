using EmegeAPI.Models;

namespace EmegeAPI.Services;

public class UserService
{
    // 
    // This is an imitation of a usable service. TODO: attach a DB to work with actual data records.
    // 

    public static UserModel? GetUser(string name)
    {
        if (name == "Greg")
        {
            return null;
        }
        else
        {
            return new UserModel(Guid.NewGuid(), name);
        }
    }
    public static UserModel? CreateUser(string name)
    {
        if (name == "Greg")
        {
            Guid user_id = Guid.NewGuid();
            return new UserModel(user_id, name);
        }
        else
        {
            return null;
        }
    }
}