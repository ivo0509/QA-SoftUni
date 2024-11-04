using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class RepeatingChecker_LastReapeatingElementTests
{
    [Test]
    public void Test_FindLastRepeatingElement_EmptyArray_ReturnsNegativeOne()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithOneInteger_ReturnsNegativeOne()
    {
        // Arrange
        int[] arrayWithOneNum = new int[] { 42 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(arrayWithOneNum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithManyNonRepeatingValues_ReturnsNegativeOne()
    {
        // Arrange
        int[] arrayWithNotEqualNums = new int[] { 42, 108, 5, 0 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(arrayWithNotEqualNums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithTwoReapeatingNegativeOneValue_ReturnsNegativeOne()
    {
        // Arrange
        int[] arrayWithRepeatingNegativeOne = new int[] { 42, 5, 108, -1, 5, -1 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(arrayWithRepeatingNegativeOne);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithManyIntegerWithSameValues_ReturnsTheIntegerValue()
    {
        // Arrange
        int[] arrayWithSameNumbers = new int[] { 42, 42, 42, 42, 42, 42 };
        int expected = 42;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(arrayWithSameNumbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithAtLeastTwoReaptingValues_ReturnsTheRepeatingValue()
    {
        // Arrange
        int[] arrayWithRepeatingNumbers = new int[] { 42, 108, 42, 5, 108, 5, 13 };
        int expected = 5;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(arrayWithRepeatingNumbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
