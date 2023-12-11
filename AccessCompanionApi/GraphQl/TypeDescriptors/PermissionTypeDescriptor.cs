using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using HotChocolate.Types;
using HotChocolate;
using HotChocolate.Data;

namespace AccessCompanionApi.GraphQl.TypeDescriptors;

public class PermissionTypeDescriptor : ObjectType<PermissionType>
{
    protected override void Configure(IObjectTypeDescriptor<PermissionType> descriptor)
    {
        descriptor.Description("This is the type of permission that a user can request. ");
        descriptor
            .Field(x => x.Id).Ignore();

        descriptor
            .Field(x => x.Permissions)
            .ResolveWith<Resolvers>(x => x.ReadPermissionsByPermissionType(default!, default!))
            .UseDbContext<AppDbContext>()
            ;
    }
    private class Resolvers
    {
        public IQueryable<Permission> ReadPermissionsByPermissionType(PermissionType permissionType, [Service] IDbContext context)
        {
            return new List<Permission>().AsQueryable();
        }
    }
}