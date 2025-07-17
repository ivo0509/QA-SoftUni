using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
   [TestFixture]
        public class HiddenMenuTests : BaseTest
        {
        [SetUp]
        public void Login()
        {
            Login("standard_user", "secret_sauce");
        }

        [Test]
        public void TestOpenMenu()
        {
            var hiddenMenuPage = new HiddenMenuPage(driver);
            hiddenMenuPage.ClickMenuButton();

            // Verify that the logout button is displayed when the menu is opened
            Assert.That(hiddenMenuPage.IsMenuOpen(), Is.True, "The menu did not open correctly.");
        }

        [Test]
        public void TestLogout()
        {
            var hiddenMenuPage = new HiddenMenuPage(driver);
            hiddenMenuPage.ClickMenuButton();
            hiddenMenuPage.ClickLogoutButton();

            // Verify that the user is redirected to the login page after logging out
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"), "The user is not redirected to the login page after logging out.");
        }
    }
}
