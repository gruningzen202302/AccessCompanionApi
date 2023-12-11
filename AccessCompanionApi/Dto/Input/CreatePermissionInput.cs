namespace AccessCompanionApi.Dto.Input;

public record CreatePermissionInput(
    int PermissionTypeId,
    string EmployeeForename,
    string EmployeeSurName,
    DateTime PermissionDay
    );