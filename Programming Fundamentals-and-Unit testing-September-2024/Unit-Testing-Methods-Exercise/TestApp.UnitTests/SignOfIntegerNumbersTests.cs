using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class SignOfIntegerNumbersTests
{
    [Test]
    public void Test_CheckSign_NotAnIntegerValue_ReturnErrorMessage()
    {
        //Arrange
        string input = "Desi";
        string expected = "The input is not an integer!";

        //Act
        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_CheckSign_ZeroValueInput_ReturnMessageForZero()
    {
        //Arrange
        string input = "0";
        string expected = "The number 0 is zero.";

        //Act
        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_CheckSign_NegativeValueInput_ReturnMessageForNegativeInteger()
    {
        //Arrange
        string input = "-9";
        string expected = "The number -9 is negative.";

        //Act
        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_CheckSign_PositiveValueInput_ReturnMessageForPositiveInteger()
    {
        //Arrange
        string input = "9";
        string expected = "The number 9 is positive.";

        //Act
        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
