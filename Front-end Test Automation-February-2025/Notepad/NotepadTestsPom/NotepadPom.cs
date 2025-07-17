using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadTestsPom
{
    public class NotepadPage
    {
        private readonly AndroidDriver _driver;

        public NotepadPage(AndroidDriver driver)
        {
            _driver = driver;
        }

        // Define elements
        public IWebElement SkipTutorialButton => _driver.FindElement(MobileBy.Id
            ("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));
        public IWebElement AddNoteButton => _driver.FindElement(MobileBy.Id
            ("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
        public IWebElement CreateTextNoteOption => _driver.FindElement
            (MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
        public IWebElement WriteNoteField => _driver.FindElement
            (MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
        public IWebElement BackButton => _driver.FindElement
            (MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
        public IWebElement NoteTitle(string title) => _driver.FindElement
            (By.XPath($"//android.widget.TextView[@resource-id='com.socialnmobile.dictapps.notepad.color.note:id/title' and @text='{title}']"));
        public IWebElement MenuButton => _driver.FindElement(MobileBy.Id
            ("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn"));
        public IWebElement DeleteOption => _driver.FindElement
            (MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")"));
        public IWebElement ConfirmDeleteButton => _driver.FindElement(MobileBy.Id("android:id/button1"));

        // Define actions
        public void SkipTutorial()
        {
            try
            {
                SkipTutorialButton.Click();
            }
            catch (NoSuchElementException)
            {
                // Tutorial skip button not found, continue with setup
            }
        }

        public void AddNote() => AddNoteButton.Click();
        public void CreateTextNote() => CreateTextNoteOption.Click();
        public void WriteNoteContent(string content) => WriteNoteField.SendKeys(content);
        public void ClickBackButton() => BackButton.Click();
        public void OpenMenu() => MenuButton.Click();
        public void ClickDeleteOption() => DeleteOption.Click();
        public void ConfirmDelete() => ConfirmDeleteButton.Click();
    }
}

