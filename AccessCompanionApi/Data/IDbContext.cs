using System.Linq;
using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Data;

public interface IDbContext
{
    IQueryable<PermissionType> PermissionTypes { get; set;}

}