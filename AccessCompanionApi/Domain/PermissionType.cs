using System.Collections.Generic;
namespace AccessCompanionApi.Domain;

public class PermissionType: EntityBase{

    public required string Description { get; set; }

    //public TimeSpan Duration { get; set; }

    public virtual required ICollection<Permission> Permissions { get; set; }

    public PermissionType()
    {
        Permissions = new List<Permission>();
    }
    public PermissionType(string description)
    {
        Permissions = new List<Permission>();
        Description = description;
    }
}