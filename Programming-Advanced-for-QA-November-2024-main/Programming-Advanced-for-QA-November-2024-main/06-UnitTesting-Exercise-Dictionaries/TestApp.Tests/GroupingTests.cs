using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> input = new List<int>();

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.Empty, "String is not empty.");
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int> { 1, 2, 3, 4, 5 };
        string expected = $"Odd numbers: 1, 3, 5" +
        $"{Environment.NewLine}Even numbers: 2, 4";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int> { 2, 4, 12, 8 };
        string expected = "Even numbers: 2, 4, 12, 8";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Input list has odd numbers.");
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int> { 1, 3, 5, 11 };
        string expected = "Odd numbers: 1, 3, 5, 11";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Input list has even numbers.");
    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int> { -2, -3, -4, -5 };
        string expected = $"Even numbers: -2, -4" +
        $"{Environment.NewLine}Odd numbers: -3, -5";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }
}
