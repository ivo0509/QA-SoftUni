using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish the test cases
    [TestCase("hello", 3, "hElLohElLohElLo")]
    [TestCase("ABCdef", 5, "aBcDeFaBcDeFaBcDeFaBcDeFaBcDeF")]
    [TestCase("Diyan", 2, "dIyAndIyAn")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input,
        int repetitionFactor, string expected)
    {
        // Arrange and Act
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException(string input)
    {
        // Arrange
        int repetitionFactor = 3;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "Sample text";
        int repetitionFactor = -1;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "Sample text";
        int repetitionFactor = 0;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }
}
