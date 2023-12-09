using System.Linq;
using AccessCompanionApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
        public DbSet<Permission> Permissions { get; set; }
        IQueryable<Permission> IDbContext.Permissions
        {
            get => Permissions;
            set => Permissions = (DbSet<Permission>)value;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<PermissionType>()
                .HasMany(p => p.Permissions)
                .WithOne(p => p.PermissionType)
                .HasForeignKey(p => p.PermissionTypeId);

        modelBuilder.Entity<Permission>()
             .HasOne(p => p.PermissionType)
             .WithMany(p => p.Permissions)
             .HasForeignKey(p => p.PermissionTypeId);

        var permissionTypeMeeting = new PermissionType
        {
            Id = 3,
            Description = "Permission used to access the meeting room",

        };
        // var permissionMeetingJohn = new Permission
        // {
        //     Id = 1,
        //     PermissionTypeId = permissionTypeMeeting.Id,
        //     PermissionType = permissionTypeMeeting,
        //     PermissionDay = new DateTime(2020, 4, 4, 0, 0, 0),
        //     EmployeeForename = "John",
        //     EmployeeSurname = "Doe",
        // };
        modelBuilder.Entity<PermissionType>()
                .HasData(
                    new PermissionType { 
                        Id=1,
                        Description = "Permision used by default when no other type is specified" 
                        },
                    new PermissionType { 
                        Id= 2,
                        Description = "Permission used to access the coworking area"
                    },
                    permissionTypeMeeting
                );
        // modelBuilder.Entity<Permission>()
        //     .HasData(
        //         new Permission
        //         {
        //             Id = 1,
        //             PermissionDay = new DateTime(2020, 1, 1, 0, 0, 0),
        //             EmployeeForename = "John",
        //             EmployeeSurname = "Doe",
        //             PermissionTypeId = permissionTypeMeeting.Id,
        //             //PermissionType = permissionTypeMeeting
        //             //PermissionType = PermissionTypes.Single(p => p.Description == "Permision used by default when no other type is specified")
        //         },
        //        new Permission
        //        {
        //            Id = 2,
        //            //PermissionType = new PermissionType { Description = "Permission for interview", Id = 3 },
        //            PermissionTypeId = 1,
        //            PermissionDay = new DateTime(2020, 2, 2, 0, 0, 0),
        //            EmployeeForename = "John",
        //            EmployeeSurname = "Doe",
        //        },
        //        new Permission
        //        {
        //            Id = 3,
        //            PermissionTypeId = permissionTypeMeeting.Id,
        //            //PermissionTypeId = 3,//PermissionTypes.Single(p=>p.Description == "Permission used to access the meeting room").Id,
        //            //PermissionType = new PermissionType { Description = "Permission for interview" },
        //            PermissionDay = new DateTime(2020, 3, 3, 0, 0, 0),
        //            EmployeeForename = "Susan",
        //            EmployeeSurname = "Smith"
        //        }
        //         );
    }
}