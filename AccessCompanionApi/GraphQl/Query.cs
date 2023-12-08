using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;

namespace  AccessCompanionApi.GraphQl;

public class Query
{
    public IQueryable<PermissionType> ReadPermissionTypes([Service] IDbContext dbContext) {
    return dbContext.PermissionTypes;
        
    }
}