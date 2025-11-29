namespace EmegeAPI.Models;

public class UserModel
{
    public UserModel(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public long Id { get; set; }
    public string Name { get; set; }
}