using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobile_Summator
{
    public class SummatorPOM
    {
        private readonly AndroidDriver _driver;

        public SummatorPOM(AndroidDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Field1 => _driver.FindElement(MobileBy.Id
            ("com.example.androidappsummator:id/editText1"));
        public IWebElement Field2 => _driver.FindElement(MobileBy.Id
            ("com.example.androidappsummator:id/editText2"));
        public IWebElement ButtonCalc => _driver.FindElement(MobileBy.Id
            ("com.example.androidappsummator:id/buttonCalcSum"));
        public IWebElement Result => _driver.FindElement(MobileBy.Id
            ("com.example.androidappsummator:id/editTextSum"));

        public string Calculator(string num1, string num2)
        {
            Field1.Clear();
            Field1.SendKeys(num1);
            Field2.Clear();
            Field2.SendKeys(num2);
            ButtonCalc.Click();

            return Result.Text;
        }
    }
}

