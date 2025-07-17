using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using NUnit.Framework;


namespace WorkingWithWindows
{
    [TestFixture]
    public class SwitchingWindowsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeDriverPath = @"C:\Program Files\ChromeDriver\chromedriver.exe"; // Replace with the actual path
            driver = new ChromeDriver(chromeDriverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test, Order(1)]
        public void HandleMultipleWindows()
        {
            // Launch the browser and open the URL
            driver.Url = "https://the-internet.herokuapp.com/windows";

            // Click on the "Click Here" link to open a new window
            driver.FindElement(By.LinkText("Click Here")).Click();

            // Get all window handles
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            // Ensure there are at least two windows open
            Assert.That(windowHandles.Count, Is.EqualTo(2), "There should be two windows open.");

            // Switch to the new window
            driver.SwitchTo().Window(windowHandles[1]);

            // Verify the content of the new window
            string newWindowContent = driver.PageSource;
            Assert.That(newWindowContent, Does.Contain("New Window"),
                        "The content of the new window is not as expected.");

            // Log the content of the new window
            string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.AppendAllText(path, "Window handle for new window: " 
                + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content: " + newWindowContent + "\n\n");

            // Close the new window
            driver.Close();

            // Switch back to the original window
            driver.SwitchTo().Window(windowHandles[0]);

            // Verify the content of the original window
            string originalWindowContent = driver.PageSource;
            Assert.That(originalWindowContent, Does.Contain("Opening a new window"),
                        "The content of the original window is not as expected.");

            // Log the content of the original window
            File.AppendAllText(path, "Window handle for original window: " 
                + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content: " + originalWindowContent + "\n\n");
        }

        [Test, Order(2)]
        public void HandleNoSuchWindowException()
        {
            // Launch the browser and open the URL
            driver.Url = "https://the-internet.herokuapp.com/windows";

            // Click on the "Click Here" link to open a new window
            driver.FindElement(By.LinkText("Click Here")).Click();

            // Get all window handles
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            // Switch to the new window
            driver.SwitchTo().Window(windowHandles[1]);

            // Close the new window
            driver.Close();

            try
            {
                // Attempt to switch back to the closed window
                driver.SwitchTo().Window(windowHandles[1]);
            }
            catch (NoSuchWindowException ex)
            {
                // Log the exception
                string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
                File.AppendAllText(path, "NoSuchWindowException caught: " + ex.Message + "\n\n");
                Assert.Pass("NoSuchWindowException was correctly handled.");
            }
            catch (Exception ex)
            {
                Assert.Fail("An unexpected exception was thrown: " + ex.Message);
            }
            finally
            {
                // Switch back to the original window
                driver.SwitchTo().Window(windowHandles[0]);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
