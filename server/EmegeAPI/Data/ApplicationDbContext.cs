using EmegeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmegeAPI.Data;

public class ApplicationDBContext : DbContext
{
    // https://ravindradevrani.medium.com/image-upload-crud-operations-in-net-core-apis-7407f111d2f4
    // https://www.c-sharpcorner.com/article/working-with-sql-lite-database-in-asp-net-core-web-api/
    // https://medium.com/codex/containerizing-a-net-app-with-postgres-using-docker-compose-a35167b419e7
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<EmegeModel> Emeges { get; set; }
}