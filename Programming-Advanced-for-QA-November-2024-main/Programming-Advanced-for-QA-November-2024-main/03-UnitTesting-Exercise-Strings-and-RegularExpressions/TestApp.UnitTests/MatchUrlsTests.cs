using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty, "The list is not empty.");
        Assert.That(result.Count, Is.EqualTo(0), "Count is more than zero.");
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "Text with no URLs";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty, "The list is not empty.");
        Assert.That(result.Count, Is.EqualTo(0), "Count is more than zero.");
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string text = "This is text with one URL: https://softuni.bg";
        string expectedURL = "https://softuni.bg";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result[0], Is.EqualTo(expectedURL), "The URL is not the same.");
        Assert.That(result.Count, Is.EqualTo(1), "There is more than one element in the list.");
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "This is text with one URL: https://softuni.bg, http://abv.bg and one more url https://www.yahoo.com/email#lesson-78195";
        string firstExpectedURL = "https://softuni.bg";
        string secondExpectedURL = "http://abv.bg";
        string thirdExpectedURl = "https://www.yahoo.com";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Arrange
        Assert.That(result[0], Is.EqualTo(firstExpectedURL), "The url in index 0 is not the expected");
        Assert.That(result[1], Is.EqualTo(secondExpectedURL), "The url in index 1 is not the expected");
        Assert.That(result[2], Is.EqualTo(thirdExpectedURl), "The url in index 2 is not the expected");
        Assert.That(result.Count, Is.EqualTo(3), "There is more than three elements in the list.");

    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "This is text with one URL: \"https://softuni.bg\"";
        string expectedURL = "https://softuni.bg";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result[0], Is.EqualTo(expectedURL), "The URL is not the same.");
        Assert.That(result.Count, Is.EqualTo(1), "There is more than one element in the list.");
    }
}
