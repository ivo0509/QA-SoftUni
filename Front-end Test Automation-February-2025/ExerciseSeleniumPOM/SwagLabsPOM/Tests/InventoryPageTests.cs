using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    [TestFixture]
    public class InventoryPageTests : BaseTest
    {

        [SetUp]
        public void Login()
        {
            Login("standard_user", "secret_sauce");
        }

        [Test]
        public void TestInventoryDisplay()
        {
            var inventoryPage = new InventoryPage(driver);
            Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True, "Inventory items are not displayed.");
        }

        [Test]
        public void TestAddToCartByIndex()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByIndex(0); // Add the first item to the cart

            var cartPage = new CartPage(driver);
            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not added to the cart.");
        }

        [Test]
        public void TestAddToCartByName()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack"); // Add item by product name

            var cartPage = new CartPage(driver);
            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not added to the cart.");
        }

        [Test]
        public void TestPageTitle()
        {
            var inventoryPage = new InventoryPage(driver);
            Assert.That(inventoryPage.IsPageLoaded(), Is.True, "The inventory page did not load correctly.");
        }

        
    }
}
        
