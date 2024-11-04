using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        //Arrange
        long primeNumber = 13;

        //Act
        long result = PrimeFactor.FindLargestPrimeFactor(primeNumber);

        //Assert
        Assert.AreEqual(primeNumber, result);
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        //Arrange
        long number = 1914;
        long expected = 29;

        //Act
        long result = PrimeFactor.FindLargestPrimeFactor(number);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
