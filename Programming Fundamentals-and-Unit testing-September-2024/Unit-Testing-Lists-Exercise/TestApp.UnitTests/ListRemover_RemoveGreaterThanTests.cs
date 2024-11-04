using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListRemover_RemoveGreaterThanTests
{
    [Test]
    public void Test_RemoveElementsGreaterThan_EmptyListParameter_ReturnsEmtyList()
    {
        // Arrange
        List<int> list = new();
        int threshold = 5;

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(list, threshold);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithGreaterThanThresholdElements_ReturnsEmptyList()
    {
        // Arrange
        List<int> list = new() { 7, 13, 28, 9 };
        int threshold = 5;

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(list, threshold);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithLessThanOrEqualToThresholdElements_ReturnsSameList()
    {
        // Arrange
        List<int> input = new() { 1, 2, 4, 5 };
        int threshold = 5;

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(input, threshold);

        // Assert
        CollectionAssert.AreEqual(input, result);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithLessThanEqualAndGreaterThanThresholdElements_ReturnsOnlyLessThanOrEqualToThreshold()
    {
        // Arrange
        List<int> input = new() { 12, 2, 14, 5 , 3 , 29};
        int threshold = 5;
        List<int> expected = new() { 2, 5, 3 };

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(input, threshold);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
