using System.Linq;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Migrations;//TODO uncomment after the first migration (this creates the folder)
namespace AccessCompanionApi.Data;

public class AppDbContext : DbContext, IDbContext{
    public AppDbContext(){ }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ 
        // TODO uncomment after the first migration (this creates the folder)
        // if (Database is null) Database.Migrate();

        // if (Database.GetPendingMigrations().Any())
        // {
        //     Database.Migrate();
        // }
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuildeer)=> optionsBuildeer.UseSqlServer();
}