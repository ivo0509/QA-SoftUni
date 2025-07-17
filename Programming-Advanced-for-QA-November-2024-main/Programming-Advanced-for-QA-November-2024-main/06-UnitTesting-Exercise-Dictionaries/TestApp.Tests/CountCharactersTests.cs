using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty, "String is not empty.");
    }

    // TODO: finish test
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new List<string>() { "", "" };

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty, "String is not empty.");
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "a" };
        string expected = "a -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That (result, Is.EqualTo(expected), "Count of character is more than 1.");
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "ab", "b", "abc" };
        string expected = $"a -> 2" +
                        $"{Environment.NewLine}b -> 3" +
                        $"{Environment.NewLine}c -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "#a$", "$@", "a$" };
        //\r\n -> кратък запис за {Environment.NewLine}
        //string expected = "# -> 1\r\na -> 2\r\n$ -> 3\r\n@ -> 1";
        string expected = $"# -> 1" +
                        $"{Environment.NewLine}a -> 2" +
                        $"{Environment.NewLine}$ -> 3" +
                        $"{Environment.NewLine}@ -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Expected result is not equal to actual result.");
    }
}
