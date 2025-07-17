using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);

            string chromeDriverPath = @"C:\Program Files\ChromeDriver\chromedriver.exe";
            driver = new ChromeDriver(chromeDriverPath, chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        protected void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var loginPage = new LoginPage(driver);
            loginPage.InputUsername(username);
            loginPage.InputPassword(password);
            loginPage.ClickLoginButton();
        }
    }
}
    
