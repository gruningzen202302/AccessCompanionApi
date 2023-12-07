using System;
using AccessCompanionApi.Abstractions;
namespace AccessCompanionApi.Test;

public class PermissionTypeShould
{
    [Fact]
    public void DummyTest()
    {
        Console.WriteLine("tests");
        int smallNumber = 1;
        Console.WriteLine("Test1");
        Assert.True(200>smallNumber);
    }
    [Fact]
    public void ReadPermissionType__PermissionExists__ReturnsPermissionType()
    {
        // Arrange
        var permissionType = new PermissionType() { Description = "Turn to use coworking area"};
        Assert.Equal("Turn to use coworking area", permissionType.Description);

        var permissionRepository = new Mock<IPermissionTypeRepository>();
        permissionRepository.Setup(x => x.ReadById(0)).Returns(permissionType);
        Assert.Equal("Turn to use coworking area", permissionRepository.Object.ReadById(0).Description);
    }
}