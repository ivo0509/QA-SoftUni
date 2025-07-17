using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    private Student _student;

    [SetUp]
    public void SetUp()
    {
        this._student = new();
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia", "Alice Johnson 22 Sofia" };
        string expected = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 22 years old.";

        // Act
        string result = _student.AddAndGetByCity(students, "Sofia");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Plovdiv" };

        // Act
        string result = _student.AddAndGetByCity(students, "Burgas");

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        // Arrange
        string[] students = Array.Empty<string>();

        // Act
        string result = _student.AddAndGetByCity(students, "Sofia");

        // Assert
        Assert.That(result, Is.Empty);
    }
}
