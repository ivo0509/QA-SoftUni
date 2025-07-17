using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Assert
        string[] input = Array.Empty<string>();

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "gold 5", "GOLD 10", "Silver 10", "SilVEr 10" };
        string expected = $"gold -> 15" +
            $"{Environment.NewLine}silver -> 20";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = new string[] { "gold 15", "gold 10", "silver 20", "silver 10" };
        string expected = $"gold -> 25" +
            $"{Environment.NewLine}silver -> 30";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
