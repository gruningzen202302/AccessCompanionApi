using System.Linq;
using AccessCompanionApi.Domain;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Migrations;//TODO uncomment after the first migration (this creates the folder)
namespace AccessCompanionApi.Data;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class AppDbContext : DbContext, IDbContext{

    public AppDbContext(){ }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ 
            // TODO uncomment after the first migration (this creates the folder)
            // if (Database is null) 
            // {
            //     Database?.Migrate();
            // }

            // if (Database.GetPendingMigrations().Any())
            // {
            //     Database.Migrate();
            // }
            //DbInitializer.Seed(this);
            
        }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuildeer) => optionsBuildeer.UseSqlServer();

        public DbSet<PermissionType> PermissionTypes { get; set; }
        IQueryable<PermissionType> IDbContext.PermissionTypes
        {
            get => PermissionTypes;
            set => PermissionTypes = (DbSet<PermissionType>)value;
        }
}