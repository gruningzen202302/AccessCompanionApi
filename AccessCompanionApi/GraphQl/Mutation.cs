using AccessCompanionApi.Data;
using System.Threading.Tasks;
using AccessCompanionApi.Dto.Input;
using AccessCompanionApi.Dto.Output;
using AccessCompanionApi.Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AccessCompanionApi.GraphQl;
public class Mutation
{

    //[UseDbContext(typeof(AppDbContext))]
    public async Task<CreatePermissionPayload> CreatePermission(CreatePermissionInput createPermissionInput, [Service] IDbContext context)
    {
        var permission = new Permission
        {
            PermissionTypeId = createPermissionInput.PermissionTypeId,
            EmployeeForename = createPermissionInput.EmployeeForename,
            EmployeeSurname = createPermissionInput.EmployeeSurName,
            PermissionDay = createPermissionInput.PermissionDay
        };
        try
        {
            permission.PermissionType = await context.PermissionTypes.FirstOrDefaultAsync(x => x.Id == createPermissionInput.PermissionTypeId) ?? new PermissionType()
            {
                Description = "No description",
                Permissions = new List<Permission>()
            };
            var entities = context.Permissions.ToList();
            entities.Add(permission);
            var saved = await context.SaveChangesAsync();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error saving permission");
            Log.Error(e.Message);
            Log.Information(e.StackTrace ?? string.Empty);
            throw;
        }
        return new CreatePermissionPayload(permission);
    }
}
