namespace EmegeAPI.Models;

public class UserModel
{
    public UserModel(Guid id, string name, DateOnly joinDate)
    {
        Id = id;
        Name = name;
        JoinDate = joinDate;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly JoinDate { get; set; }
}