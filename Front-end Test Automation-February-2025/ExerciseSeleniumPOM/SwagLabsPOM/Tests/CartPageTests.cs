using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    [TestFixture]
    public class CartPageTests : BaseTest
    {

        [SetUp]
        public void LoginAndAddItemToCart()
        {
            Login("standard_user", "secret_sauce");
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByIndex(0); // Add the first item to the cart
            inventoryPage.ClickCartLink(); // Navigate to the cart page
        }

        [Test]
        public void TestCartItemDisplayed()
        {
            var cartPage = new CartPage(driver);
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not displayed in the cart.");
        }

        [Test]
        public void TestClickCheckout()
        {
            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            // Assert that the user is redirected to the checkout page
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"), "The checkout page did not load after clicking checkout.");
        }
    }
}
    

