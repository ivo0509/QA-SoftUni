using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace WorkingWithIFrames
{
    public class IFrameTests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var chromeDriverPath = @"C:\Program Files\ChromeDriver\chromedriver.exe"; // Replace with the actual path
            driver = new ChromeDriver(chromeDriverPath);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test, Order(1)]
        public void TestFrameByIndex()
        {
            driver.Url = "https://codepen.io/pervillalva/full/abPoNLd";

            // Wait until the iframe is available and switch to it by finding the first iframe
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

            // Click the dropdown button
            var dropdownButton = wait.Until(ExpectedConditions
                .ElementIsVisible(By.CssSelector(".dropbtn")));
            dropdownButton.Click();

            // Select the links inside the dropdown menu
            var dropdownLinks = wait.Until(ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            // Verify and print the link texts
            foreach (var link in dropdownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.That(link.Displayed, Is.True, "Link inside the dropdown is not displayed as expected.");
            }

            driver.SwitchTo().DefaultContent();
        }


        [Test, Order(2)]
        public void TestFrameById()
        {
            driver.Url = "https://codepen.io/pervillalva/full/abPoNLd";

            // Wait until the iframe is available and switch to it by ID
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

            // Click the dropdown button
            var dropdownButton = wait.Until(ExpectedConditions
                .ElementIsVisible(By.CssSelector(".dropbtn")));
            dropdownButton.Click();

            // Select the links inside the dropdown menu
            var dropdownLinks = wait.Until(ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            // Verify and print the link texts
            foreach (var link in dropdownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.That(link.Displayed, Is.True, "Link inside the dropdown is not displayed as expected.");
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test, Order(3)]
        public void TestFrameByWebElement()
        {
            driver.Url = "https://codepen.io/pervillalva/full/abPoNLd";

            // Locate the frame element
            var frameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));

            // Switch to the frame by web element
            driver.SwitchTo().Frame(frameElement);

            // Click the dropdown button
            var dropdownButton = wait.Until(ExpectedConditions
                .ElementIsVisible(By.CssSelector(".dropbtn")));
            dropdownButton.Click();

            // Select the links inside the dropdown menu
            var dropdownLinks = wait.Until(ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            // Verify and print the link texts
            foreach (var link in dropdownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.That(link.Displayed, Is.True, "Link inside the dropdown is not displayed as expected.");
            }

            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}