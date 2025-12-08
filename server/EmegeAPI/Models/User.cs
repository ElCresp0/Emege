using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmegeAPI.Models;

[Index(nameof(Name), IsUnique = true)]
public class UserModel
{
    public UserModel(string name, Guid? id = null, DateOnly? joinDate = null)
    {
        Name = name;
        Id = (id == null) ? new Guid() : (Guid)id;
        JoinDate = (joinDate == null) ? DateOnly.FromDateTime(DateTime.Now) : (DateOnly)joinDate;
    }

    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateOnly JoinDate { get; set; }
}