using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class MiddleCharactersTests
{
    [Test]
    public void Test_GetMiddleChars_EmptyString_ReturnsEmptyStringMessage()
    {
        //Arrange
        string input = "";
        string expectedText = "Empty string";

        //Act
        string resultText = MiddleCharacters.GetMiddleChars(input);

        //Assert
        Assert.AreEqual(expectedText, resultText); 
    }

    [Test]
    public void Test_GetMiddleChars_WhiteSpaceString_ReturnsEmptyStringMessage()
    {
        //Arrange
        string input = "     ";
        string expectedText = "Empty string";

        //Act
        string resultText = MiddleCharacters.GetMiddleChars(input);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetMiddleChars_SingleCharacterString_ReturnsTheCharacter()
    {
        //Arrange
        string input = "a";
        string expectedText = "a";

        //Act
        string resultText = MiddleCharacters.GetMiddleChars(input);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetMiddleChars_EvenStringLength_ReturnsTwoCharactersString()
    {
        //Arrange
        string input = "tables";
        string expectedText = "bl";

        //Act
        string resultText = MiddleCharacters.GetMiddleChars(input);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetMiddleChars_OddStringLength_ReturnsOneCharactersString()
    {
        //Arrange
        string input = "table";
        string expectedText = "b";

        //Act
        string resultText = MiddleCharacters.GetMiddleChars(input);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }
}
