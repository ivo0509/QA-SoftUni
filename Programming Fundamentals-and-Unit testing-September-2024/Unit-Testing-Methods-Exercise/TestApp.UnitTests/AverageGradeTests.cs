using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class AverageGradeTests
{
    [Test]
    public void Test_GetGradeDefinition_AverageGradeUnderTwo_ReturnsErrorMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 1, -3, 4, 5 };
        string expectedText = "Incorrect grades";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);

    }

    [Test]
    public void Test_GetGradeDefinition_AverageGradeOverSix_ReturnsErrorMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 9, 7, 8, 10 };
        string expectedText = "Incorrect grades";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetGradeDefinition_FailScoreAverageGrade_ReturnsFailDefinitionMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 2, 3, 2, 3 };
        string expectedText = "Fail";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetGradeDefinition_PoorScoreAverageGrade_ReturnsPoorDefinitionMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 3, 3, 2, 2.70, 4, 4 };
        string expectedText = "Poor";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetGradeDefinition_GoodScoreAverageGrade_ReturnsGoodDefinitionMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 3, 3, 3.90, 3.70, 4, 4 };
        string expectedText = "Good";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetGradeDefinition_VeryGoodScoreAverageGrade_ReturnsVeryGoodDefinitionMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 5, 5, 4, 4.50, 5 };
        string expectedText = "Very good";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }

    [Test]
    public void Test_GetGradeDefinition_ExcellentScoreAverageGrade_ReturnsExcellentDefinitionMessage()
    {
        //Arrange
        List<double> grades = new List<double> { 5.30, 6, 6, 5.50, 5.70, 6 };
        string expectedText = "Excellent";

        //Act
        string resultText = AverageGrade.GetGradeDefinition(grades);

        //Assert
        Assert.AreEqual(expectedText, resultText);
    }
}
