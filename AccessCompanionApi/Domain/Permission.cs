using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Domain;
public class Permission:EntityBase
{
    public Permission()
    {
        PermissionType = new () { Description = "Default permission type" };
    }

    public int PermissionTypeId { get; set; }
    public virtual PermissionType PermissionType { get; set; }
    public DateTime PermissionDay { get; set; }
    public required string EmployeeForename { get; set; }
    public required string EmployeeSurname { get; set; }
}