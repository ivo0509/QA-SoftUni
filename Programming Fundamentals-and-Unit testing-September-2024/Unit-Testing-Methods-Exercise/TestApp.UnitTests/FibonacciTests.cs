using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        //Arrange
        int number = 0;
        int expected = 0;

        //Act
        int result = Fibonacci.CalculateFibonacci(number);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        //Arrange
        int number = 6;
        int expected = 8;

        //Act
        int result = Fibonacci.CalculateFibonacci(number);

        //Assert
        Assert.AreEqual(expected, result);
    }
}