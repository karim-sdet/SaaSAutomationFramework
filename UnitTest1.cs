using NUnit.Framework;
using SaaSAutomationFramework.Drivers;
using SaaSAutomationFramework.Pages;

namespace SaaSAutomationFramework.Tests
{
    [TestFixture]
    public class LoginTests
    {
        [SetUp]
        public void SetUp()
        {
            // Start Chrome before each test
            DriverFactory.InitDriver();
        }

        [TearDown]
        public void TearDown()
        {
            // Close browser after each test
            DriverFactory.QuitDriver();
        }

        [Test]
        public void ValidLogin_ShouldNavigateToProductsPage()
        {
            var loginPage = new LoginPage();

            loginPage.GoTo();
            loginPage.Login("standard_user", "secret_sauce");

            // After successful login, URL should contain 'inventory'
            StringAssert.Contains("inventory", DriverFactory.Driver.Url);
        }

        [Test]
        public void InvalidLogin_ShouldShowErrorMessage()
        {
            var loginPage = new LoginPage();

            loginPage.GoTo();
            loginPage.Login("standard_user", "wrong_password");

            var errorMessage = loginPage.GetErrorMessage();

            Assert.IsNotEmpty(errorMessage, "Expected an error message for invalid login.");
        }

        [Test]
        public void AddItemToCart_ShouldIncreaseCartCount()
        {
            var loginPage = new LoginPage();
            var productsPage = new ProductsPage();

            // Login first
            loginPage.GoTo();
            loginPage.Login("standard_user", "secret_sauce");

            // Verify we are on Products page
            Assert.IsTrue(productsPage.IsAtProductsPage(), "Products page was not loaded after login.");

            // Add first item to cart
            productsPage.AddFirstItemToCart();

            // Verify cart badge shows 1
            int cartCount = productsPage.GetCartCount();
            Assert.AreEqual(1, cartCount, "Expected cart count to be 1 after adding one item.");

            // Optional: open cart page so you can visually see the item during run
            productsPage.OpenCart();
        }
    }
}
