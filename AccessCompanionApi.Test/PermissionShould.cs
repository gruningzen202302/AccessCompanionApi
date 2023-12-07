using AccessCompanionApi.Abstractions;

namespace AccessCompanionApi.Test;

public class PermissionShould{
    [Fact]
    public void ReadPermission__PermissionExists__ReturnsPermission(){
        //Arrange
        var permission= new Permission(){
            PermissionType = new PermissionType(){Description = "Turn to use coworking area"},
            PermissionDay = DateTime.Now,
            EmployeeForename = "John",
            EmployeeSurname = "Doe",
            
            };
    }
}