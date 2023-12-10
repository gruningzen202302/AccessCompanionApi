using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using System.ComponentModel.DataAnnotations;
using HotChocolate;


namespace AccessCompanionApi.GraphQl;
[GraphQLDescription("This is the GraphQL API for the AccessCompanionApi. ")]
public class Query
{
    [UseProjection]
    [GraphQLDescription("Get Permissions")]
    public IQueryable<Permission> ReadPermissions([Service] IDbContext dbContext)
    {
        return dbContext.Permissions;
    }
    //[UseProjection]
    // public IQueryable<PermissionType> ReadPermissionTypes([Service] IDbContext dbContext) {
    // return dbContext.PermissionTypes;

    // }
}