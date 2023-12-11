using AccessCompanionApi.Abstractions;

namespace AccessCompanionApi.Test;

public class PermissionShould{
    [Fact]
    public void ReadPermission__PermissionExists__ReturnsPermission(){
        //Arrange
        //Act
        var permission= new Permission(){
            Id = 0,
            PermissionType = new PermissionType(){
                Description = "Turn to use coworking area",
                Permissions = new List<Permission>()
                },
            PermissionDay = DateTime.Now,
            EmployeeForename = "John",
            EmployeeSurname = "Doe",
            
            };
        //Assert 
        Assert.Equal("Turn to use coworking area", permission.PermissionType.Description);

        //Act
        var permissionRepository = new Mock<IPermissionRepository>();
        permissionRepository.Setup(x => x.ReadById(0)).Returns(permission);
        
        //Assert
        Assert.Equal("Turn to use coworking area", permissionRepository.Object.ReadById(0).PermissionType.Description);

    }
}