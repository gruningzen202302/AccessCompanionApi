using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Data;
public interface IDbContext
{
    IQueryable<PermissionType> PermissionTypes { get; set;}
    IQueryable<Permission> Permissions { get; set;}
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default(CancellationToken));
}