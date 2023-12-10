using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;

namespace AccessCompanionApi.GraphQl.TypeDescriptors;
public class PermissionDescriptor : ObjectType<Permission>
{
    protected override void Configure(IObjectTypeDescriptor<Permission> permissionDescriptor)
    {
        permissionDescriptor.Description("Represents a permission to access a resource. ");
        permissionDescriptor.Field(x => x.Id).Ignore();
        permissionDescriptor.Field(x => x.PermissionTypeId).Ignore();
        permissionDescriptor
            .Field(permission => permission.PermissionType)
            .ResolveWith<Resolvers>(x => x.ReadPermissionTypeByPermissionId(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the type of permission requested.\n For more details see the PermissionType.Description property.");

    }
    private class Resolvers
    {
        public PermissionType ReadPermissionTypeByPermissionId(Permission permission, [Service] IDbContext context)
        {
            return context.PermissionTypes.Single(permissionType => permissionType.Id.Equals(permission.PermissionTypeId));
        }
    }
}