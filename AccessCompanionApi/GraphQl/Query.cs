using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using System.ComponentModel.DataAnnotations;
using HotChocolate;
using Microsoft.EntityFrameworkCore;


namespace AccessCompanionApi.GraphQl;
[GraphQLDescription("This is the GraphQL API for the AccessCompanionApi. ")]
public class Query
{
    [UseProjection, UseFiltering, UseSorting]
    [GraphQLDescription("Get Permissions")]

    public IQueryable<Permission> ReadPermissions([Service] IDbContext dbContext)
    {
        return dbContext
            .Permissions
            //.Include(permission => permission.PermissionType)
            ;
    }
}