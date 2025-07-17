using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] input = new string[] { "rose" };
        string expected = $"Plants with 4 letters:" +
            $"{Environment.NewLine}rose";

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That (result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] input = new string[] {  "Violet", "Rose", "Mint", "Dahlia", "Orchid" };
        string expected = $"Plants with 4 letters:" +
            $"{Environment.NewLine}Rose" +
            $"{Environment.NewLine}Mint"+
            $"{Environment.NewLine}Plants with 6 letters:" +
            $"{Environment.NewLine}Violet" +
            $"{Environment.NewLine}Dahlia" +
            $"{Environment.NewLine}Orchid";

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseSensitive()
    {
        // Arrange
        string[] input = new string[] { "VioLet", "Rose", "MINT", "DahLIA", "Orchid" };
        string expected = $"Plants with 4 letters:" +
            $"{Environment.NewLine}Rose" +
            $"{Environment.NewLine}MINT" +
            $"{Environment.NewLine}Plants with 6 letters:" +
            $"{Environment.NewLine}VioLet" +
            $"{Environment.NewLine}DahLIA" +
            $"{Environment.NewLine}Orchid";

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
