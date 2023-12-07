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
        Assert.True(200<smallNumber);
    }
}