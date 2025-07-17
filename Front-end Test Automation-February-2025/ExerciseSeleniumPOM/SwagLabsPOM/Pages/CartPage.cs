using OpenQA.Selenium;

namespace SwagLabsPOM.Pages
{
    public class CartPage : BasePage
    {
        private readonly By cartItem = By.CssSelector(".cart_item");
        private readonly By checkoutButton = By.CssSelector("#checkout");

        public CartPage(IWebDriver driver) : base(driver) { }

        public bool IsCartItemDisplayed()
        {
            return FindElement(cartItem).Displayed;
        }

        public void ClickCheckout()
        {
            Click(checkoutButton);
        }
    }
}