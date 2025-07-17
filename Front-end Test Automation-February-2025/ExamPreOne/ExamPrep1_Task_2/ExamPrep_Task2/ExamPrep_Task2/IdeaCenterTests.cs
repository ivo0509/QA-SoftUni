using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExamPrep_Task2
{
    public class IdeaCenterTests
    {
        private IWebDriver driver;
        Random random;
        private static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/";

        string lastCreatedIdeaTilte = "";
        string lastCreatedIdeaDescription = "";


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(BaseUrl);

            driver.FindElement(By.CssSelector("[class='btn btn-outline-info px-3 me-2']")).Click();
            driver.FindElement(By.XPath("//input[@name='Email']")).SendKeys("examPrepUser_1@abv.bg");
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys("examPrepUser_1");

            driver.FindElement(By.XPath("//button[text()='Sign in']")).Click();
        }

        [Test,Order(1)]
        public void CreateIdeaWithInvalidData()
        {
            //Arrange
            var title = "";
            var description = "";

            driver.FindElement(By.XPath("//a[text()='Create Idea']")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='Title']")).SendKeys(title);
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(description);

            driver.FindElement(By.CssSelector("[type='submit']")).Click();
            var errorMessage = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text;

            //Assert
            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Ideas/Create"));

            Assert.That(errorMessage, Is.EqualTo("Unable to create new Idea!"));
        }

        [Test, Order(2)]
        public void CreateRandomIdeaWithCorrectData()
        {
            //Arrange
            lastCreatedIdeaTilte = GenerateRandomString("title");
            lastCreatedIdeaDescription = GenerateRandomString("description");

            driver.FindElement(By.XPath("//a[text()='Create Idea']")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='Title']")).SendKeys(lastCreatedIdeaTilte);
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(lastCreatedIdeaDescription);

            driver.FindElement(By.CssSelector("[type='submit']")).Click();
                
            //Asserts
            Assert.That(driver.FindElement(By.Id("search-input")), Is.Not.Null);

            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Ideas/MyIdeas"));

            var createdIdeaDescription = driver.FindElement(By.XPath($"//p[contains(text(),'{lastCreatedIdeaDescription}')]")).Text;

            Assert.That(createdIdeaDescription, Is.EqualTo(lastCreatedIdeaDescription));
        }

        [Test, Order(3)]
        public void ViewLastCreatedIdeaTest()
        {
            Assert.That(lastCreatedIdeaTilte, Is.Not.Null, "No title set for the last created idea.");

            Console.WriteLine("Viewing idea with title: " + lastCreatedIdeaTilte);

            driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ideaCards = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")));

            Assert.That(ideaCards.Count, Is.GreaterThan(0), "No idea cards were found on the page.");

            var lastIdeaCard = ideaCards.Last();

            var viewButton = lastIdeaCard.FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(viewButton).Perform();

            viewButton.Click();

            var ideaTitleElement = driver.FindElement(By.CssSelector("h1.mb-0.h4"));

            // Assertion to verify the title of the idea
            string ideaTitle = ideaTitleElement.Text.Trim();
            Assert.That(ideaTitle, Is.EqualTo(lastCreatedIdeaTilte), "The title of the idea does not match the expected value.");

        }

        [Test, Order(4)]
        public void EditLastCreatedIdeaTitleTest()
        {
            Assert.IsNotNull(lastCreatedIdeaTilte, "No title set for the last created idea.");

            Console.WriteLine("Editing idea with title: " + lastCreatedIdeaTilte);

            driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));

            Assert.IsTrue(ideaCards.Count > 0, "No idea cards were found on the page.");

            var lastIdeaCard = ideaCards.Last();
            var editButton = lastIdeaCard.FindElement(By.CssSelector("a[href*='/Ideas/Edit']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();
            Console.WriteLine("Clicked 'Edit' button using Actions class.");

            var titleInput = driver.FindElement(By.Id("form3Example1c"));
            string newTitle = "Changed Title: " + lastCreatedIdeaTilte;
            titleInput.Clear();
            titleInput.SendKeys(newTitle);

            var editSubmitButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            editSubmitButton.Click();
            Console.WriteLine("Clicked 'Edit' button to save changes.");

            driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");

            ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));
            lastIdeaCard = ideaCards.Last();
            var viewButton = lastIdeaCard.FindElement(By.CssSelector("a[href*='/Ideas/Read']"));
            actions.MoveToElement(viewButton).Click().Perform();
            Console.WriteLine("Clicked 'View' button to verify the edited idea.");

            var ideaTitleElement = driver.FindElement(By.CssSelector("h1.mb-0.h4"));
            string ideaTitle = ideaTitleElement.Text.Trim();
            Assert.That(ideaTitle, Is.EqualTo(newTitle), "The title of the idea does not match the expected value.");

        }

        [Test, Order(5)]
        public void EditIdeaDescriptionTest()
        {
            driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));

            Assert.IsTrue(ideaCards.Count > 0, "No idea cards were found on the page.");

            var lastIdeaCard = ideaCards.Last();
            var editButton = lastIdeaCard.FindElement(By.CssSelector("a[href*='/Ideas/Edit']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();

            string newDescription = "Changed Description: " + lastCreatedIdeaDescription;
            lastCreatedIdeaDescription = newDescription;

            var descriptionField = wait.Until(driver => driver.FindElement(By.Id("form3Example4cd")));
            descriptionField.Clear();
            descriptionField.SendKeys(newDescription);

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            //there is a need of wait here due to slowness of the system
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card.mb-4.box-shadow")));


            string expectedUrl = $"{BaseUrl}Ideas/MyIdeas";

            Assert.That(driver.Url, Is.EqualTo(expectedUrl), "The URL after editing did not match the expected URL.");

            ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));
            lastIdeaCard = ideaCards.Last();
            var ideaDescriptionElement = lastIdeaCard.FindElement(By.CssSelector("p.card-text"));

            Assert.That(ideaDescriptionElement.Text.Trim(), Is.EqualTo(newDescription), "The description of the idea did not update as expected.");

        }

        [Test, Order(6)]
        public void DeleteLastIdeaTest()
        {
            driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));

            Assert.IsTrue(ideaCards.Count > 0, "No idea cards were found on the page.");

            var lastIdeaCard = ideaCards.Last();
            var deleteButton = lastIdeaCard.FindElement(By.CssSelector("a[href*='/Ideas/Delete']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(deleteButton).Click().Perform();


            ideaCards = driver.FindElements(By.CssSelector(".card.mb-4.box-shadow"));

            bool isIdeaDeleted = ideaCards.All(card => !card.Text.Contains(lastCreatedIdeaDescription));
            Assert.IsTrue(isIdeaDeleted, "The idea was not deleted successfully or is still visible in the list.");

        }
        private string GenerateRandomString(string prefix)
        {
            random = new Random();

            return prefix + random.Next(999, 99999).ToString();
        }

        [OneTimeTearDown]
        public void TearDown()
        { 
            driver.Close();
            driver.Dispose();
        }
    }
}