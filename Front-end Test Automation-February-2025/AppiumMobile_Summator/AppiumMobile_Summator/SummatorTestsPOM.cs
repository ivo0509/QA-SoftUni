using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumMobile_Summator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private AndroidDriver _driver;
        private AppiumLocalService _appiumLocalService;
        private SummatorPOM _summatorPOM;

        [OneTimeSetUp]
        public void Setup()
        {
            //This starts Appium server no need to start it via CMD
            _appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            _appiumLocalService.Start();

            var androidOptions = new AppiumOptions();
            androidOptions.PlatformName = "Android";
            androidOptions.AutomationName = "UIAutomator2";
            androidOptions.DeviceName = "Pixel9";
            androidOptions.App = @"D:\com.example.androidappsummator.apk";

            _driver = new AndroidDriver(_appiumLocalService.ServiceUrl, androidOptions);
            _summatorPOM = new SummatorPOM(_driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _appiumLocalService.Dispose();
        }

        [Test]
        public void Test_ValidData_Pom()
        {
            var result = _summatorPOM.Calculator("5", "5");
            Assert.That(result, Is.EqualTo("10"));
        }

        [Test]
        public void Test_InvalidData_Pom()
        {
            var result = _summatorPOM.Calculator("aaa", "5");
            Assert.That(result, Is.EqualTo("error"));
        }
    }
}