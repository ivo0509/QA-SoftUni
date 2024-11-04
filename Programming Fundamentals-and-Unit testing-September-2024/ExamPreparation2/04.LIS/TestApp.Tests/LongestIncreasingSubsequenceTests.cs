using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        // Arrange,
        int[] nullArray = null;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => LongestIncreasingSubsequence.GetLis(nullArray));
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();
        string expected = string.Empty;

        // Act 
        string result = LongestIncreasingSubsequence.GetLis(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        // Arrange
        int[] arrayWithOneElement = new int[] { 1 };
        string expected = "1";

        // Act 
        string result = LongestIncreasingSubsequence.GetLis(arrayWithOneElement);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        // Arrange
        int[] unsortedNumbers = new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
        string expected = "0 4 6 9 13 15";

        // Act 
        string result = LongestIncreasingSubsequence.GetLis(unsortedNumbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        // Arrange
        int[] sortedArray = new int[] { 1, 2, 3, 4 };
        string expected = "1 2 3 4";

        // Act 
        string result = LongestIncreasingSubsequence.GetLis(sortedArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
