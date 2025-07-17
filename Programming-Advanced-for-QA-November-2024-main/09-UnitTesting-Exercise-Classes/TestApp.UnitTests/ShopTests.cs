using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void SetuUp()
    {
        _shop = new Shop();
    } 

    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        string[] products = new string[] { "98765 Gizmo 2 8", "12345 Widget 5 10", "54321 Gadget 3 15" };

        string expected = $"12345{Environment.NewLine}-- Widget - $10.00: 5{Environment.NewLine}-- $50.00{Environment.NewLine}54321{Environment.NewLine}-- Gadget - $15.00: 3{Environment.NewLine}-- $45.00{Environment.NewLine}98765{Environment.NewLine}-- Gizmo - $8.00: 2{Environment.NewLine}-- $16.00";

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        // Arrange
        string[] products = Array.Empty<string>();

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
