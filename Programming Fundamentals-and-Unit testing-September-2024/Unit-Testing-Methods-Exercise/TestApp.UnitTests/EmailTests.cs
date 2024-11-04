using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailTests
{
   
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act
        bool isValid = Email.IsValidEmail(validEmail);

        // Assert
        Assert.IsTrue(isValid);
    }

    [Test]
    public void Test_IsValidEmail_InvalidEmail()
    {
        // Arrange
        string invalidMail = "test@";

        // Act
        bool isValid = Email.IsValidEmail(invalidMail);

        // Assert
        Assert.IsFalse(isValid);
    }

    [Test]
    public void Test_IsValidEmail_NullInput()
    {
        // Arrange
        string nullEmail = null;

        // Act
        bool isValid = Email.IsValidEmail(nullEmail);

        // Assert
        Assert.IsFalse(isValid);
    }
}
