using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articles = new string[] { "Article#1 Content1 Author1", "Article#2 Content2 Author2", "Article#3 Content3 Author3" };
        string firstArticleTitle = "Article#1";
        string secondArticleContent = "Content2";
        string thirdArticleAuthor = "Author3";

        // Act
        Article result = _article.AddArticles(articles);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo(firstArticleTitle));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo(secondArticleContent));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo(thirdArticleAuthor));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] articles = new string[] { "SeaGarden Content2 Author2", "NewPresident Content1 Author1", "RadioNews Content3 Author3"  };

        Article testArticle = _article.AddArticles(articles);
        string expected = $"NewPresident - Content1: Author1{Environment.NewLine}" +
                          $"RadioNews - Content3: Author3{Environment.NewLine}" +
                          $"SeaGarden - Content2: Author2";

        // Act
        string result = _article.GetArticleList(testArticle, "title");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] articles = new string[] { "SeaGarden Content2 Author2", "NewPresident Content1 Author1", "RadioNews Content3 Author3" };

        Article testArticle = _article.AddArticles(articles);

        // Act
        string result = _article.GetArticleList(testArticle, "invalid");

        // Assert
        Assert.That(result, Is.Empty);
    }
}
