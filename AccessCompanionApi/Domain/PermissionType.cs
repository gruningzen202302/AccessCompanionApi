namespace AccessCompanionApi.Domain;

public class PermissionType: EntityBase{
    public required string Description { get; set; }

    public PermissionType(){ }
    public PermissionType(string description)
    {
        Description = description;
    }
}