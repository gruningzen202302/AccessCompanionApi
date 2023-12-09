using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using System.ComponentModel.DataAnnotations;
using HotChocolate;


namespace AccessCompanionApi.GraphQl;
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