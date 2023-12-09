namespace AccessCompanionApi.Domain;

public class PermissionType: EntityBase{

    [GraphQLDescription("A brief description of the permission type.")]
    public required string Description { get; set; }

    //public TimeSpan Duration { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; }

    public PermissionType(){ 
        Permissions = new HashSet<Permission>();
    }
    public PermissionType(string description)
    {
        Permissions = new HashSet<Permission>();
        Description = description;
    }
}