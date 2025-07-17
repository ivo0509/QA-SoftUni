using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FoodyTests
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";

        private string lastCreatedFoodName;

        private string lastCreatedFoodDescription;

        private Random random;

        [OneTimeSetUp]
        public void Setup()
        {
            random = new Random();
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


            //Login to the system
            driver.Navigate().GoToUrl(BaseUrl + "User/Login");
            driver.FindElement(By.XPath("//input[@name='Username']")).SendKeys("examPrepUser_2");
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys("examPrepUser_2");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Test, Order(1)]
        public void AddFoodWithIvalidData_Test()
        {
            //Arrange
            string invalidFoodName = "";
            string invalidFoodDescrioption = "";

            driver.FindElement(By.XPath("//a[text()='Add Food']")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='Name']")).SendKeys(invalidFoodName);
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(invalidFoodDescrioption);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //Assert
            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Food/Add"));

            var errorMessage = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text;

            Assert.That(errorMessage.Trim(), Is.EqualTo("Unable to add this food revue!"));
        }

        [Test, Order(2)]
        public void AddFoodWithValidData_Test()
        {
            //Arrange
            lastCreatedFoodName = "Tilte_" + random.Next(999, 99999).ToString();
            lastCreatedFoodDescription = "Description_"+ random.Next(999, 99999).ToString();

            driver.FindElement(By.XPath("//a[text()='Add Food']")).Click();

            //Act

            driver.FindElement(By.CssSelector("[name='Name']")).SendKeys(lastCreatedFoodName);
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(lastCreatedFoodDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //Asserts
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var homePageElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='FOODY']")));

            Assert.That(driver.Url, Is.EqualTo(BaseUrl));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Foody.WebApp"));

            var lastCreatedFood = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//h2"));

            Assert.That(lastCreatedFood.Text, Is.EqualTo(lastCreatedFoodName));
        }

        [Test, Order(3)]
        public void EditLastCreatedFood()
        {
            //Arrange
            driver.FindElement(By.XPath("//a[text()='FOODY']")).Click();
            var editedName = "Edited";

            var lastFoodEditButton = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Edit']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(lastFoodEditButton).Perform();

            lastFoodEditButton.Click();

            //Act
            driver.FindElement(By.CssSelector("[name='Name']")).SendKeys(editedName);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //Assert
            var lastCreatedFoodNameText = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//h2")).Text;

            Assert.That(lastCreatedFoodNameText, Is.EqualTo(lastCreatedFoodName));

            Console.WriteLine("The title remains unchaged due to unimplemented functionallity");
        }

        [Test, Order(4)]
        public void SerachForFoodTest()
        {
            //Arrange
            driver.FindElement(By.XPath("//a[text()='FOODY']")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='keyword']")).SendKeys(lastCreatedFoodName);
            driver.FindElement(By.CssSelector("[type='submit']")).Click();

            //Assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.UrlContains($"keyword={lastCreatedFoodName}"));

            var allFoodContainers = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));

            Assert.That(allFoodContainers.Count(), Is.EqualTo(1));

            var lastCreatedFoodNameText = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//h2")).Text;

            Assert.That(lastCreatedFoodNameText, Is.EqualTo(lastCreatedFoodName));
        }

        [Test, Order(5)]
        public void DeleteLastCreatedFood()
        {
            //Arrange
            driver.FindElement(By.XPath("//a[text()='FOODY']")).Click();

            var initialCount = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']")).Count();

            var lastFoodContainer = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(lastFoodContainer).Perform();

            Assert.That(lastFoodContainer.Enabled, Is.True);
            Assert.That(lastFoodContainer.Displayed, Is.True);

            //Act
            driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Delete']")).Click();

            //Asserts
            var countAfterDeletion = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']")).Count();

            Assert.That(countAfterDeletion, Is.EqualTo(initialCount - 1));
        }

        [Test, Order(6)]
        public void SearchForDeletedFood()
        {
            //Arrange
            driver.FindElement(By.XPath("//a[text()='FOODY']")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='keyword']")).SendKeys(lastCreatedFoodName);
            driver.FindElement(By.CssSelector("[type='submit']")).Click();

            //Asserts
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[alt='empty plate picture']")));

            var noResultsMessage = driver.FindElement(By.XPath("//h2[@class='display-4']"));
            var addFoodButton = driver.FindElement(By.XPath("//a[text()='Add food']"));

            Assert.That(noResultsMessage.Text, Is.EqualTo("There are no foods :("));
            Assert.That(addFoodButton.Displayed, Is.True);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { 
            driver.Quit();
            driver.Dispose();
        }
    }
}