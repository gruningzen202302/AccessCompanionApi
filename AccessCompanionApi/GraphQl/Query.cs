using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using System.ComponentModel.DataAnnotations;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using AccessCompanionApi.Abstractions;
using AccessCompanionApi.Infrastructure;

namespace AccessCompanionApi.GraphQl;

[GraphQLDescription("This is the GraphQL API for the AccessCompanionApi. ")]
public class Query
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IDbContext _context;

    public Query([Service] IDbContext context)
    {
        _context = context;
        _permissionRepository = new PermissionRepository(context);
    }

    [UseProjection, UseFiltering, UseSorting]
    [GraphQLDescription("Get Permissions")]

    public IQueryable<Permission> ReadPermissions()
    {
        return _permissionRepository.ReadAll();
    }
}