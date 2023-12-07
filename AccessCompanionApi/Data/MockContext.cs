using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using Microsoft.EntityFrameworkCore;

public class MockContext : DbContext, IDbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static MockContext _singletonMockContext;

    internal static MockContext SingletonMockContext{
        get{
            if(_singletonMockContext is null){
                _singletonMockContext = new();
            }
            return _singletonMockContext;
        }
    }
    public IQueryable<PermissionType> PermissionTypes { get; set ; }

    public MockContext()
    {
        PermissionType defaultPermissionType = new(){
            Id = 1,
            Description = "Permision used by default when no other type is specified",
        };
        PermissionType coworkingPermissionType = new(){
            Id = 2,
            Description = "Permission used to access the coworking area",
        };
        var permissionTypes = new PermissionType[]{
            defaultPermissionType, 
            coworkingPermissionType
            };
        PermissionTypes = permissionTypes.AsQueryable();
    }
}
#pragma warning restore CS8618 