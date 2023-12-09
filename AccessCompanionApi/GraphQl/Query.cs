using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;

namespace  AccessCompanionApi.GraphQl;

public class Query
{
    //[UseProjection]
    public IQueryable<PermissionType> ReadPermissionTypes([Service] IDbContext dbContext) {
    return dbContext.PermissionTypes;
        
    }
    [UseProjection]
    public IQueryable<Permission> ReadPermissions([Service] IDbContext dbContext)
    {
        return dbContext.Permissions;
    }
}