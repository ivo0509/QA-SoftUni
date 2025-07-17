using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SearchWithExplicitWait
{
    public class ExplicitWaitSearchProduct
    {
        [TestFixture]
        public class ExplicitWaitTests
        {
            IWebDriver driver;

            [SetUp]
            public void Setup()
            {
                var chromeDriverPath = @"C:\Program Files\ChromeDriver\chromedriver.exe"; // Replace with the actual path
                driver = new ChromeDriver(chromeDriverPath);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Url = "http://practice.bpbonline.com/";
            }

            [Test, Order(1)]
            public void SearchProduct_Keyboard_ShouldAddToCart()
            {
                // Fill in the search field textbox
                driver.FindElement(By.Name("keywords")).SendKeys("keyboard");

                // Click on the search icon
                driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

                // Set the implicit wait to 0 before using explicit wait
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

                try
                {
                    // Create WebDriverWait object with timeout set to 10 seconds
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                    // Wait to identify the Buy Now link using the LinkText property
                    IWebElement buyNowLink = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

                    // Set the implicit wait back to 10 seconds
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    buyNowLink.Click();

                    // Verify text
                    Assert.That(driver.PageSource.Contains("keyboard"), Is.True,
                                "The product 'keyboard' was not found in the cart page.");
                    Console.WriteLine("Scenario completed");
                }
                catch (Exception ex)
                {
                    Assert.Fail("Unexpected exception: " + ex.Message);
                }
            }

            [Test, Order(2)]
            public void SearchProduct_Junk_ShouldThrowNoSuchElementException()
            {
                // Fill in the search field textbox
                driver.FindElement(By.Name("keywords")).SendKeys("junk");

                // Click on the search icon
                driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

                // Set the implicit wait to 0 before using explicit wait
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

                try
                {
                    // Create WebDriverWait object with timeout set to 10 seconds
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                    // Wait to identify the Buy Now link using the LinkText property
                    IWebElement buyNowLink = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

                    // If found, fail the test as it should not exist
                    buyNowLink.Click();
                    Assert.Fail("The 'Buy Now' link was found for a non-existing product.");
                }
                catch (WebDriverTimeoutException)
                {
                    // Expected exception for non-existing product
                    Assert.Pass("Expected WebDriverTimeoutException was thrown.");
                }
                catch (Exception ex)
                {
                    Assert.Fail("Unexpected exception: " + ex.Message);
                }
                finally
                {
                    // Reset the implicit wait
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
            }

            [TearDown]
            public void TearDown()
            {
                driver.Dispose();
            }
        }
    }
}