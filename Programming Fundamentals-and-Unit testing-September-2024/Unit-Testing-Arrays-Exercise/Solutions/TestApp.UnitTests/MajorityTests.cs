using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class MajorityTests
{
    [Test]
    public void Test_IsEvenOrOddMajority_EmpryArray_ReturnsZero()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();
        int expected = 0;

        // Act
        int result = Majority.IsEvenOrOddMajority(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_IsEvenOrOddMajority_ArrayOnlyWithZeros_ReturnsZero()
    {
        // Arrange
        int[] arrayWithZeros = new int[] {0, 0, 0, 0};
        int expected = 0;

        // Act
        int result = Majority.IsEvenOrOddMajority(arrayWithZeros);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_IsEvenOrOddMajority_EqualOddAndEvenNumbers_ReturnsZero()
    {
        // Arrange
        int[] arrayWithEqualMajority = new int[] { 2, 12, 5, 7 };
        int expected = 0;

        // Act
        int result = Majority.IsEvenOrOddMajority(arrayWithEqualMajority);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_IsEvenOrOddMajority_EvenMajority_ReturnsPositiveNumber()
    {
        // Arrange
        int[] arrayWithEvenMajority = new int[] { 2, 12, 5, 6 };

        // Act
        int result = Majority.IsEvenOrOddMajority(arrayWithEvenMajority);

        // Assert
        Assert.That(result, Is.GreaterThan(0));
    }

    [Test]
    public void Test_IsEvenOrOddMajority_OddMajority_ReturnsNegativeNumber()
    {
        // Arrange
        int[] arrayWithOddMajority = new int[] { 2, 3, 5, 9 };

        // Act
        int result = Majority.IsEvenOrOddMajority(arrayWithOddMajority);

        // Assert
        Assert.That(result, Is.LessThan(0));
    }
}
