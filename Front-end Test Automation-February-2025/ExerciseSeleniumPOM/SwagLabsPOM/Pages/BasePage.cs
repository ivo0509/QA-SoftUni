using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SwagLabsPOM.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement FindElement(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        protected IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        protected void Click(By by)
        {
            FindElement(by).Click();
        }

        protected void Type(By by, string text)
        {
            var element = FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By by)
        {
            return FindElement(by).Text;
        }

    }
}