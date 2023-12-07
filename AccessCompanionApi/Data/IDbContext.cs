using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Data;
public interface IDbContext
{
    IQueryable<PermissionType> PermissionTypes { get; set;}
    IQueryable<Permission> Permissions { get; set;}

}