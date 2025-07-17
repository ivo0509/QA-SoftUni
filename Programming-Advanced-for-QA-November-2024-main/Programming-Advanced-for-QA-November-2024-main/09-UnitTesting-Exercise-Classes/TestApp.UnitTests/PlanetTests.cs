using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PlanetTests
{
    [Test]
    public void Test_CalculateGravity_ReturnsCorrectCalculation()
    {
        // Arrange
        Planet earth = new("Earth", 12_742, 149_600_000, 1);
        double mass = 1_000;
        double expectedGravity = mass * 6.67430e-11 / Math.Pow(earth.Diameter / 2, 2);

        // Act
        double resultGravity = earth.CalculateGravity(mass);

        // Assert
        Assert.That(resultGravity, Is.EqualTo(expectedGravity));
    }

    [Test]
    public void Test_GetPlanetInfo_ReturnsCorrectInfo()
    {
        // Arrange
        Planet mars = new Planet("Mars", 6_789, 227_900_000, 2);

        string expectedInfo = $"Planet: Mars{Environment.NewLine}" +
                              $"Diameter: 6789 km{Environment.NewLine}" +
                              $"Distance from the Sun: 227900000 km{Environment.NewLine}" +
                              $"Number of Moons: 2";

        // Act 
        string resultInfo = mars.GetPlanetInfo();

        // Assert
        Assert.That(resultInfo, Is.EqualTo(expectedInfo));
    }
}
