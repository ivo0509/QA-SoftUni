using OpenQA.Selenium;

namespace SwagLabsPOM.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");
        private readonly By errorMessage = By.CssSelector(".error-message-container.error");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void InputUsername(string username)
        {
            Type(usernameField, username);
        }

        public void InputPassword(string password)
        {
            Type(passwordField, password);
        }

        public void ClickLoginButton()
        {
            Click(loginButton);
        }

        public string GetErrorMessage()
        {
            return GetText(errorMessage);
        }
    }
}