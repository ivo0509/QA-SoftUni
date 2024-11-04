using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[] charArray = new char[] { 'A', 'z', '3', '#', '9' };
        char[] expected = new char[] { 'A', 'z', '#' };

        // Act
        char[] result = Fake.RemoveStringNumbers(charArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        // Arrange
        char[] charArray = new char[] { 'A', 'b', 'c', '$' };
        char[] expected = new char[] { 'A', 'b', 'c', '$' };

        // Act
        char[] result = Fake.RemoveStringNumbers(charArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        char[] emptyArray = Array.Empty<char>();

        // Act
        char[] result = Fake.RemoveStringNumbers(emptyArray);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
