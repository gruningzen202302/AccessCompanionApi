using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Domain;

[GraphQLDescription("Represents a permission to access a resource. ")]
public class Permission:EntityBase
{
    public Permission()
    {
        PermissionType = new () { Description = "Default permission type" };
    }

    public int PermissionTypeId { get; set; }

    [GraphQLDescription("This is the type of permission requested.\n For more details see the PermissionType.Description property.")]
    public virtual PermissionType PermissionType { get; set; }

    [GraphQLDescription("The resource requested is available from this date.")]
    public DateTime PermissionDay { get; set; }
    [GraphQLDescription("The user that requested the resource. The user must belong to the Company.")]
    public required string EmployeeForename { get; set; }
    [GraphQLDescription("The user that requested the resource. The user must belong to the Company.")]
    public required string EmployeeSurname { get; set; }
}