using OpenQA.Selenium;
using SaaSAutomationFramework.Drivers;

namespace SaaSAutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        // SauceDemo login URL
        private readonly string _loginUrl = "https://www.saucedemo.com/";

        // Locators
        private readonly By _usernameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");

        // Navigate to login page
        public void GoTo()
        {
            Driver.Navigate().GoToUrl(_loginUrl);
        }

        // Perform login
        public void Login(string username, string password)
        {
            Type(_usernameInput, username);
            Type(_passwordInput, password);
            Click(_loginButton);
        }

        // Read error message (for invalid login)
        public string GetErrorMessage()
        {
            try
            {
                return GetText(_errorMessage);
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
