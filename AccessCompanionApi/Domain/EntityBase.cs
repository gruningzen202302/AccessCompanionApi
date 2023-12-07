using System.ComponentModel.DataAnnotations;

namespace AccessCompanionApi.Domain;

public class EntityBase{
    [Key] public int Id { get; set; }
}