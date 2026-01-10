using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmegeAPI.Models;

[Index(nameof(Name), IsUnique = true)]
public class UserModel
{
    public UserModel()
    // Empty constructor required by EntityFramework
    {
        Name = "";
        Id = new Guid();
        JoinDate = new DateOnly();
    }
    public UserModel(string Name, Guid? Id = null, DateOnly? JoinDate = null)
    {
        this.Name = Name;
        this.Id = (Id == null) ? Guid.NewGuid() : (Guid)Id;
        this.JoinDate = (JoinDate == null) ? DateOnly.FromDateTime(DateTime.Now) : (DateOnly)JoinDate;
    }

    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateOnly JoinDate { get; set; }
}