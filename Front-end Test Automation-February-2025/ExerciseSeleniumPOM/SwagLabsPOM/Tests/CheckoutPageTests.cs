using OpenQA.Selenium;
using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {


        [SetUp]
        public void LoginAndAddItemToCart()
        {
            Login("standard_user", "secret_sauce");
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByIndex(0); // Add the first item to the cart
            inventoryPage.ClickCartLink(); // Navigate to the cart page
            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout(); // Proceed to the checkout page
        }

        [Test]
        public void TestCheckoutPageLoaded()
        {
            var checkoutPage = new CheckoutPage(driver);
            Assert.That(checkoutPage.IsPageLoaded(), Is.True, "The checkout page did not load correctly.");
        }

       
        [Test]
        public void TestContinueToNextStep()
        {
            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.EnterFirstName("John");
            checkoutPage.EnterLastName("Doe");
            checkoutPage.EnterPostalCode("12345");
            checkoutPage.ClickContinue();

            // Assert that the user is redirected to the next step in the checkout process
            Assert.That(driver.Url.Contains("checkout-step-two.html"), Is.True, "The user was not redirected to the next step in the checkout process.");
        }

        [Test]
        public void TestCompleteOrder()
        {
            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.EnterFirstName("John");
            checkoutPage.EnterLastName("Doe");
            checkoutPage.EnterPostalCode("12345");
            checkoutPage.ClickContinue();

            // Click the "Finish" button
            checkoutPage.ClickFinish();

            // Assert that the user is redirected to the checkout complete page
            Assert.That(driver.Url.Contains("checkout-complete.html"), Is.True, "The user was not redirected to the checkout complete page.");

            // Assert that the order completion message is displayed
            Assert.That(checkoutPage.IsCheckoutComplete(), Is.True, "The order completion message was not displayed.");
        }
    }
}