using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListSplitterTests
{
    [Test]
    public void Test_SplitEvenAndOdd_EmptyListParameter_ReturnsEmptyEvenAndOddLists()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(emptyList);

        // Assert
        Assert.That(result.evens, Is.Empty);
        Assert.That(result.odds, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_OnlyEvenValues_ReturnsEmptyOddList()
    {
        // Arrange
        List<int> input = new() { 2, 4, 6 };

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(input);

        // Assert
        CollectionAssert.AreEqual(input, result.evens);
        Assert.That(result.odds, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_OnlyOddValues_ReturnsEmptyEvenList()
    {
        // Arrange
        List<int> input = new() { 1, 3, 5 };

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(input);

        // Assert
        CollectionAssert.AreEqual(input, result.odds);
        Assert.That(result.evens, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_EvenAndOddValues_ReturnsListWithCorrectValues()
    {
        // Arrange
        List<int> input = new() { 1, 2, 3, 4, 5, 6, 7 };
        List<int> expectedOdds = new() { 1, 3, 5, 7 };
        List<int> expectedEvens = new() { 2, 4, 6 };

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(input);

        // Assert
        CollectionAssert.AreEqual(expectedOdds, result.odds);
        CollectionAssert.AreEqual(expectedEvens, result.evens);

    }
}
