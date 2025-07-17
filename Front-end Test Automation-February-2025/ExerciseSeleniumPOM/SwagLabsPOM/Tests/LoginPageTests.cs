using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    [TestFixture]
        public class LoginPageTests : BaseTest
        {
            [Test]
            public void TestLoginWithValidCredentials()
            {
                Login("standard_user", "secret_sauce");

                // Assert that the user is redirected to the inventory page
                var inventoryPage = new InventoryPage(driver);
                Assert.That(inventoryPage.IsPageLoaded(), Is.True, "The inventory page did not load after login with valid credentials.");
        }

            [Test]
            public void TestLoginWithInvalidCredentials()
            {
                Login("invalid_user", "invalid_password");
                
                var loginPage = new LoginPage(driver);
                string error = loginPage.GetErrorMessage();
                
                Assert.That(error, Contains.Substring("Epic sadface: Username and password do not match any user in this service"));
            }

            [Test]
            public void TestLoginWithLockedOutUser()
            {
                Login("locked_out_user", "secret_sauce");

                var loginPage = new LoginPage(driver);
                string error = loginPage.GetErrorMessage();
                
                Assert.That(error, Contains.Substring("Epic sadface: Sorry, this user has been locked out."));
        }
    }
    }