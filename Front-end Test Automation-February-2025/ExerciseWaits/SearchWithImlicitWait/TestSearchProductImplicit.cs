using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SearchWithImlicitWait
{
    public class ImplicitWaitSearchProduct
    {
        [TestFixture]
        public class ImplicitWaitTests
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

                try
                {
                    // Click on Buy Now link
                    driver.FindElement(By.LinkText("Buy Now")).Click();

                    // Verify text
                    Assert.That(driver.PageSource, Does.Contain("keyboard"),
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

                try
                {
                    // Try to click on Buy Now link
                    driver.FindElement(By.LinkText("Buy Now")).Click();
                }
                catch (NoSuchElementException ex)
                {
                    // Verify the exception for non-existing product
                    Assert.Pass("Expected NoSuchElementException was thrown.");
                    Console.WriteLine("Timeout - " + ex.Message);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Unexpected exception: " + ex.Message);
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