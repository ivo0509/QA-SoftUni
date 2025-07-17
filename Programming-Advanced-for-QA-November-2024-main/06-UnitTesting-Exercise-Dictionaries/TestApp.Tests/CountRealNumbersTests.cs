using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] input = Array.Empty<int>();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.Empty, "String is not empty.");
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 42 };
        string expected = "42 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "The count of number 42 in not 1.");
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 42, 5, 42, 2, 5, 5 };
        string expected = $"2 -> 1" +
                         $"{Environment.NewLine}5 -> 3" +
                         $"{Environment.NewLine}42 -> 2";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { -42, -5, -42, -2, -5, -5 };
        string expected = $"-42 -> 2" +
                         $"{Environment.NewLine}-5 -> 3" +
                         $"{Environment.NewLine}-2 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 42, -5, 42, 0, -5, -5 };
        string expected = $"-5 -> 3" +
                         $"{Environment.NewLine}0 -> 1" +
                         $"{Environment.NewLine}42 -> 2";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }
}
