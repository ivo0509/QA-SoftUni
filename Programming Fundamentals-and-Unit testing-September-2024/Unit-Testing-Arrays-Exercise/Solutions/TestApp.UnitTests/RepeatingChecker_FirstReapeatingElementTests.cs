using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class RepeatingChecker_FirstReapeatingElementTests
{
    [Test]
    public void Test_FindFirstRepeatingElement_EmptyArray_ReturnsNegativeOne()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithOneInteger_ReturnsNegativeOne()
    {
        // Arrange
        int[] arrayWithOneNum = new int[] { 42 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(arrayWithOneNum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithManyNonRepeatingValues_ReturnsNegativeOne()
    {
        // Arrange
        int[] arrayWithNotEqualNums = new int[] { 42, 108, 5, 0 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(arrayWithNotEqualNums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithTwoReapeatingNegativeOneValue_ReturnsNegativeOne()
    {
        // Arrange
        int[] arrayWithRepeatingNegativeOne = new int[] { 42, 108, -1, 5, -1, 5 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(arrayWithRepeatingNegativeOne);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithManyIntegerWithSameValues_ReturnsTheIntegerValue()
    {
        // Arrange
        int[] arrayWithSameNumbers = new int[] { 42, 42, 42, 42, 42, 42 };
        int expected = 42;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(arrayWithSameNumbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithAtLeastTwoReaptingValues_ReturnsTheRepeatingValue()
    {
        // Arrange
        int[] arrayWithRepeatingNumbers = new int[] { 42, 108, 42, 5, 108, 5 };
        int expected = 42;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(arrayWithRepeatingNumbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
