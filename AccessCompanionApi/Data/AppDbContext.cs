using System.Linq;
using AccessCompanionApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
namespace AccessCompanionApi.Data;

//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class AppDbContext : DbContext, IDbContext{

    public AppDbContext(){ }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    //#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuildeer) => optionsBuildeer.UseSqlServer();

        public DbSet<PermissionType> PermissionTypes { get; set; }
        IQueryable<PermissionType> IDbContext.PermissionTypes
        {
            get => PermissionTypes;
            set => PermissionTypes = (DbSet<PermissionType>)value;
        }
        public DbSet<Permission> Permissions { get; set; }
        IQueryable<Permission> IDbContext.Permissions
        {
            get => Permissions;
            set => Permissions = (DbSet<Permission>)value;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Permission>()
            .HasOne(p => p.PermissionType)
            .WithMany(p => p.Permissions)
            .HasForeignKey(p => p.PermissionTypeId);

        var permissionTypeMeeting = new PermissionType
        {
            Id = 3,
            Description = "Permission used to access the meeting room",
            Permissions = new List<Permission>()
        };
        modelBuilder.Entity<PermissionType>()
                .HasData(
                    new PermissionType { 
                        Id=1,
                        Description = "Permision used by default when no other type is specified",
                        Permissions = new List<Permission>()
                    },
                    new PermissionType { 
                        Id= 2,
                        Description = "Permission used to access the coworking area",
                        Permissions = new List<Permission>()
                    },
                    permissionTypeMeeting
                );
    }
}