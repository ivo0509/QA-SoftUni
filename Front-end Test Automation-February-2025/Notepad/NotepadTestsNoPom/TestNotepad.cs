using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;


namespace NotepadTestsNoPom
{
    [TestFixture]
    public class NotepadTests
    {
        private AndroidDriver _driver;
        private AppiumLocalService _appiumLocalService; 
        

        [OneTimeSetUp]
        public void Setup()
        {
            _appiumLocalService = new AppiumServiceBuilder()
                  .WithIPAddress("127.0.0.1")
                  .UsingPort(4723)
                  .Build();
              _appiumLocalService.Start();

            var androidOptions = new AppiumOptions();
             androidOptions.PlatformName = "Android";
            androidOptions.AutomationName = "UIAutomator2";
            androidOptions.DeviceName = "Pixel9";
            androidOptions.App = @"D:\Notepad.apk";
            androidOptions.AddAdditionalAppiumOption("autoGrantPermissions", true);

            _driver = new AndroidDriver(_appiumLocalService.ServiceUrl, androidOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                var skipTutorial = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));
                skipTutorial.Click();
            }
            catch (NoSuchElementException)
            {
                // Tutorial skip button not found, continue with setup
            }

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _appiumLocalService.Dispose();
        }

        [Test, Order(1)]
        public void Test_CreateNote()

        {
            var addNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
            addNote.Click();
            var createTextNote = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
            createTextNote.Click();

            var writeNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
            writeNote.SendKeys("Test_1");

            var back = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
            back.Click();
            back.Click();

            var note = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));

            Assert.That(note, Is.Not.Null, "The note was not created successfully.");

            Assert.That(note.Text, Is.EqualTo("Test_1"), "The note content does not match.");
        }

        [Test,Order(2)]
        public void Test_EditNote()
        {
            var addNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
            addNote.Click();

            var createTextNote = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
            createTextNote.Click();

            var writeNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
            writeNote.SendKeys("Test_2");

            var backButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
            backButton.Click();
            backButton.Click();

            var note = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Test_2\")"));
            note.Click();

            var editButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn"));
            editButton.Click();

            var editNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
            editNote.Click();
            editNote.Clear();
            editNote.SendKeys("Edited");

            var back = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
            back.Click();
            back.Click();

            var editedNote = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Edited\")"));


            // Assertion: Verify the note was edited by checking the updated content
            Assert.That(editedNote.Text, Is.EqualTo("Edited"), "The note content does not match.");
        }

        [Test,Order(3)]
        public void Test_DeleteNote()
        {
            var addNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
            addNote.Click();

            var createTextNote = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
            createTextNote.Click();
            var writeNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
            writeNote.SendKeys("Note for Delete");

            var backButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
            backButton.Click();


            var menu = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn"));
            menu.Click();
                        
            var deleteOption = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")"));
            deleteOption.Click();

            var ok = _driver.FindElement(MobileBy.Id("android:id/button1"));
            ok.Click();

            var deletedNote = _driver.FindElements(By.XPath("//android.widget.TextView[@text='Note for Delete']"));
            Assert.That(deletedNote, Is.Empty, "The note was not deleted successfully.");

        }
    }
}