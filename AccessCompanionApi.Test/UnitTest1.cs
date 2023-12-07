using System;
namespace AccessCompanionApi.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Console.WriteLine("tests");
        int smallNumber = 1;
        Console.WriteLine("Test1");
        Assert.True(200>smallNumber);
    }
    [Fact]
    public void ReadPermissionType__PermissionExists__ReturnsPermission()
    {
        // Arrange
        
        //var permissionType = new PermissionType("Turn to use coworking area");
        // var permissionRepository = new Mock<IPermissionTypeRepository>();
        // permissionRepository.Setup(x => x.GetPermissionType(permissionType)).Returns(permissionType);
        // var permissionTypeService = new PermissionTypeService(permissionTypeRepository.Object);

        // // Act
        // var result = permissionTypeService.GetPermission(permissionType);

        // // Assert
        // Assert.Equal(permissionType, result);
    }
}