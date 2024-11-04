using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListRemover_RemoveLessThanOrEqualToTests
{
    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_EmptyListParameter_ReturnsEmtyList()
    {
        // Arrange
        List<int> list = new();
        int threshold = 5;

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, threshold);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithLessThanOrEqualToThresholdElements_ReturnsEmtyList()
    {
        // Arrange
        List<int> list = new() { 1, 2, 4, 5 };
        int threshold = 5;

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, threshold);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithOnlyGreaterThanThresholdElements_ReturnsSameList()
    {
        // Arrange
        List<int> list = new() { 7, 13, 28, 9 };
        int threshold = 5;

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, threshold);

        // Assert
        CollectionAssert.AreEqual(list, result);
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithLessThanEqualAndGreaterThanThresholdElements_ReturnsOnlyGreaterThanThreshold()
    {
        // Arrange
        List<int> input = new() { 12, 2, 14, 5, 3, 29 };
        int threshold = 5;
        List<int> expected = new() { 12, 14, 29 };

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(input, threshold);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
