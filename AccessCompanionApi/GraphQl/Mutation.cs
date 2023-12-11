using AccessCompanionApi.Data;
using System.Threading.Tasks;
using AccessCompanionApi.Dto.Input;
using AccessCompanionApi.Dto.Output;
using AccessCompanionApi.Domain;

namespace AccessCompanionApi.GraphQl;
public class Mutation
{

    //[UseDbContext(typeof(AppDbContext))]
    public async Task<CreatePermissionPayload> AddPermission(CreatePermissionInput addPermissionInput, [Service] IDbContext context)
    {
        var permission = new Permission
        {
            PermissionTypeId = addPermissionInput.PermissionTypeId,
            EmployeeForename = addPermissionInput.EmployeeForename,
            EmployeeSurname = addPermissionInput.EmployeeSurName,
            PermissionDay = addPermissionInput.PermissionDay
        };
        throw new NotImplementedException();
    }
}
