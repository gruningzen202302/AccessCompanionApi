using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Domain;

//[GraphQLDescription("Represents a permission to access a resource. ")]
public class Permission:EntityBase
{
    public Permission()
    {
        PermissionType = new()
        {
            Description = "Default permission type",
            Permissions = new List<Permission>()
        };
    }

    public int PermissionTypeId { get; set; }

    public virtual PermissionType PermissionType { get; set; }

    public DateTime PermissionDay { get; set; }
    public required string EmployeeForename { get; set; }
    public required string EmployeeSurname { get; set; }
}