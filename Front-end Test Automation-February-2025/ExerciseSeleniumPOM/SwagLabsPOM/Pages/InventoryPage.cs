using OpenQA.Selenium;

namespace SwagLabsPOM.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly By cartLink = By.CssSelector(".shopping_cart_link");
        private readonly By productsTitle = By.ClassName("title");
        private readonly By inventoryItems = By.CssSelector(".inventory_item");

        public InventoryPage(IWebDriver driver) : base(driver) { }

        // Add to cart by item index
        public void AddToCartByIndex(int itemIndex)
        {
            var itemAddToCartButton = By.CssSelector($".inventory_item:nth-child({itemIndex + 1}) .btn_inventory");
            Click(itemAddToCartButton);
        }

        // Add to cart by product name
        public void AddToCartByName(string productName)
        {
            var itemAddToCartButton = By.XPath($"//div[text()='{productName}']" +
                $"/ancestor::div[@class='inventory_item']//button[contains(@class, 'btn_inventory')]");
            Click(itemAddToCartButton);
        }

        public void ClickCartLink()
        {
            Click(cartLink);
        }

        public bool IsInventoryDisplayed()
        {
            return FindElements(inventoryItems).Any();
        }

        public bool IsPageLoaded()
        {
            return GetText(productsTitle) == "Products" && driver.Url.Contains("inventory.html");
        }
    }
}