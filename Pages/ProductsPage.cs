using OpenQA.Selenium;

namespace SaaSAutomationFramework.Pages
{
    public class ProductsPage : BasePage
    {
        // Locators
        private readonly By _pageTitle = By.CssSelector("span.title");
        private readonly By _firstAddToCart = By.CssSelector("button.btn_inventory");
        private readonly By _shoppingCartIcon = By.CssSelector("a.shopping_cart_link");
        private readonly By _cartBadge = By.CssSelector("span.shopping_cart_badge");

        public bool IsAtProductsPage()
        {
            // Products page has title "Products"
            var titleText = GetText(_pageTitle);
            return titleText.Equals("Products", StringComparison.OrdinalIgnoreCase);
        }

        public void AddFirstItemToCart()
        {
            Click(_firstAddToCart);
        }

        public int GetCartCount()
        {
            try
            {
                var text = GetText(_cartBadge);
                return int.Parse(text);
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }

        public void OpenCart()
        {
            Click(_shoppingCartIcon);
        }
    }
}
