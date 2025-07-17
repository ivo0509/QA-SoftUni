using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace WorkingWithAlerts
{
        [TestFixture]
        public class AlertTests
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
            public void HandleBasicAlert()
            {
                // Launch the browser and open the URL
                driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

                // Click on the "Click for JS Alert" button
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Alert')]")).Click();

                // Switch to the alert
                IAlert alert = driver.SwitchTo().Alert();

                // Verify the alert text
                Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"), "Alert text is not as expected.");

                // Accept the alert
                alert.Accept();

                // Verify the result message
                IWebElement resultElement = driver.FindElement(By.Id("result"));
                Assert.That(resultElement.Text, Is.EqualTo("You successfully clicked an alert"), 
                    "Result message is not as expected.");
            }

            [Test, Order(2)]
            public void HandleConfirmAlert()
            {
                // Launch the browser and open the URL
                driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

                // Click on the "Click for JS Confirm" button
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]")).Click();

                // Switch to the alert
                IAlert alert = driver.SwitchTo().Alert();

                // Verify the alert text
                Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"), "Alert text is not as expected.");

                // Accept the alert
                alert.Accept();

                // Verify the result message
                IWebElement resultElement = driver.FindElement(By.Id("result"));
                Assert.That(resultElement.Text, Is.EqualTo("You clicked: Ok"), 
                    "Result message is not as expected after accepting the alert.");

                // Trigger the alert again
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]")).Click();

                // Switch to the alert
                alert = driver.SwitchTo().Alert();

                // Dismiss the alert
                alert.Dismiss();

                // Verify the result message
                resultElement = driver.FindElement(By.Id("result"));
                Assert.That(resultElement.Text, Is.EqualTo("You clicked: Cancel"), 
                    "Result message is not as expected after dismissing the alert.");
            }

            [Test, Order(3)]
            public void HandlePromptAlert()
            {
                // Launch the browser and open the URL
                driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

                // Click on the "Click for JS Prompt" button
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Prompt')]")).Click();

                // Switch to the alert
                IAlert alert = driver.SwitchTo().Alert();

                // Verify the alert text
                Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"), "Alert text is not as expected.");

                // Send text to the alert
                string inputText = "Hello there!";
                alert.SendKeys(inputText);

                // Accept the alert
                alert.Accept();

                // Verify the result message
                IWebElement resultElement = driver.FindElement(By.Id("result"));
                Assert.That(resultElement.Text, Is.EqualTo("You entered: " + inputText), 
                    "Result message is not as expected after entering text in the prompt.");
            }

            [TearDown]
            public void TearDown()
            {
                driver.Dispose();
            }
        }
    }
