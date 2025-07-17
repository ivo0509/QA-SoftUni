using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DataDriven
{
    [TestFixture]
    public class TestCalculator
    {
        IWebDriver driver;
        IWebElement textBoxFirstNum;
        IWebElement textBoxSecondNum;
        IWebElement dropDownOperation;
        IWebElement calcBtn;
        IWebElement resetBtn;
        IWebElement divResult;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "file:///C:/Users/mddim/OneDrive/Desktop/number-calculator/number-calculator.html";

            textBoxFirstNum = driver.FindElement(By.Id("number1"));
            dropDownOperation = driver.FindElement(By.Id("operation"));
            textBoxSecondNum = driver.FindElement(By.Id("number2"));
            calcBtn = driver.FindElement(By.Id("calcButton"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        public void PerformCalculation(string firstNumber, string operation, 
                                        string secondNumber, string expectedResult)
        {
            // Click the [Reset] button
            resetBtn.Click();

            // Send values to the corresponding fields if they are not empty
            if (!string.IsNullOrEmpty(firstNumber))
            {
                textBoxFirstNum.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                textBoxSecondNum.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperation).SelectByText(operation);
            }

            // Click the [Calculate] button
            calcBtn.Click();

            // Assert the expected and actual result text are equal
            Assert.That(divResult.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("5", "+ (sum)", "10", "Result: 15")]
        [TestCase("3.5", "- (subtract)", "1.2", "Result: 2.3")]
        [TestCase("2e2", "* (multiply)", "1.5", "Result: 300")]
        [TestCase("5", "/ (divide)", "0", "Result: Infinity")]
        [TestCase("invalid", "+ (sum)", "10", "Result: invalid input")]
        public void TestNumberCalculator(string firstNumber, string operation, 
                                            string secondNumber, string expectedResult)
        {
            PerformCalculation(firstNumber, operation, secondNumber, expectedResult);
        }
    }
}