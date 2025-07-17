using NUnit.Framework;
namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    [TestCase("test@example.com")]
    [TestCase("user123@gmail.com")]
    [TestCase("jane.doe@company.co.uk")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange and Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("test")]
    [TestCase("user123@")]
    [TestCase("jane.doe@.uk")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange and Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
