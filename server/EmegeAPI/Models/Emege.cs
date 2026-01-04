using System.ComponentModel.DataAnnotations.Schema;

namespace EmegeAPI.Models;

public enum Visibility
{
    PRIVATE, // TODO: Enable encryption of ImageLocation and it's content
    PUBLIC,
    RESTRICTED
}

public class EmegeModel
{
    public EmegeModel(Guid id, string name, string imageLocation, DateOnly uploadDate,
        Visibility visibility = Visibility.PUBLIC, List<Guid>? allowedUsers = null,
        List<Guid>? likes = null)
    {
        Id = id;
        Name = name;
        ImageLocation = imageLocation;
        UploadDate = uploadDate;
        Visibility = visibility;
        AllowedUsers = allowedUsers;
        Likes = (likes == null) ? new List<Guid>() : likes;
    }

    public Guid Id { get; set; }
    [ForeignKey("UserModel")]
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string ImageLocation { get; set; }
    public DateOnly UploadDate { get; set; }
    public Visibility Visibility { get; set; }
    public List<Guid>? AllowedUsers { get; set; }
    public List<Guid> Likes { get; set; }
}