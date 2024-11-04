using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, "5 5 13 13")]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, "7 7 7 19 19 19")]
    [TestCase(new int[0], "")]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, "2 2 2 2")]
    [TestCase(new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, "13 13 21 21")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        //Arrange and Act
        string result = FoldSum.FoldArray(arr);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
