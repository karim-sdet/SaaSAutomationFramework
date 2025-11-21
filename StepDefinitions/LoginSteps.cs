using NUnit.Framework;
using TechTalk.SpecFlow;
using SaaSAutomationFramework.Pages;

namespace SaaSAutomationFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage = new();
        private readonly ProductsPage _productsPage = new();

        [Given(@"I am on the SauceDemo login page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            _loginPage.GoTo();
        }

        [When(@"I log in with valid credentials")]
        public void WhenILogInWithValidCredentials()
        {
            _loginPage.Login("standard_user", "secret_sauce");
        }

        [When(@"I log in with invalid credentials")]
        public void WhenILogInWithInvalidCredentials()
        {
            _loginPage.Login("standard_user", "wrong_password");
        }

        [Then(@"I should be navigated to the products page")]
        public void ThenIShouldBeNavigatedToTheProductsPage()
        {
            Assert.IsTrue(_productsPage.IsAtProductsPage(),
                "Products page was not loaded after valid login.");
        }

        [Then(@"I should see a login error message")]
        public void ThenIShouldSeeALoginErrorMessage()
        {
            var message = _loginPage.GetErrorMessage();
            Assert.IsNotEmpty(message, "Expected an error message for invalid login.");
        }
    }
}
