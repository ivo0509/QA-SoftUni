using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class PalindromeIntegersTests
{
    [Test]
    public void Test_FindPalindromes_EmptyList_ReturnsEmptyList()
    {
        //Arrange
        List<int> emptyList = new();
        PalindromeIntegers pl = new PalindromeIntegers(); //създаваме обект от класа, чрез който да изпълним медота

        //Act
        List<int> result = pl.FindPalindromes(emptyList);

        //Assert
        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_FindPalindromes_NoPalindromes_ReturnsEmptyList()
    {
        //Arrange
        List<int> numbers = new List<int> { 12, 45, 345, 765, 897 };
        PalindromeIntegers pl = new PalindromeIntegers(); //създаваме обект от класа, чрез който да изпълним медота

        //Act
        List<int> result = pl.FindPalindromes(numbers);

        //Assert
        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_FindPalindromes_OnlySingleDigitsElements_ReturnsSameIntegersList()
    {
        //Arrange
        List<int> numbers = new List<int> { 1, 4, 3, 7, 9 };
        PalindromeIntegers pl = new PalindromeIntegers(); //създаваме обект от класа, чрез който да изпълним медота

        //Act
        List<int> result = pl.FindPalindromes(numbers);

        //Assert
        CollectionAssert.AreEqual(numbers, result);
    }

    [Test]
    public void Test_FindPalindromes_AllElementsArePalindromes_ReturnsSameIntegersList()
    {
        //Arrange
        List<int> numbers = new List<int> { 121, 323, 454, 676 };
        PalindromeIntegers pl = new PalindromeIntegers(); //създаваме обект от класа, чрез който да изпълним медота

        //Act
        List<int> result = pl.FindPalindromes(numbers);

        //Assert
        CollectionAssert.AreEqual(numbers, result);
    }

    [Test]
    public void Test_FindPalindromes_PalimdromesAndNoPalindromesIntegers_ReturnsOnlyPalindromes()
    {
        //Arrange
        List<int> numbers = new List<int> { 121, 323, 54, 1234, 454, 676 };
        List<int> expectedList = new List<int> { 121, 323, 454, 676 };
        PalindromeIntegers pl = new PalindromeIntegers(); //създаваме обект от класа, чрез който да изпълним медота

        //Act
        List<int> result = pl.FindPalindromes(numbers);

        //Assert
        CollectionAssert.AreEqual(expectedList, result);
    }
}
