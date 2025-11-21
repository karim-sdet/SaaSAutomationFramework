using OpenQA.Selenium;
using SaaSAutomationFramework.Drivers;

namespace SaaSAutomationFramework.Pages
{
    // Common base class for all page objects
    public abstract class BasePage
    {
        // We get the driver instance from DriverFactory
        protected IWebDriver Driver => DriverFactory.Driver;

        // Small helper to find elements
        protected IWebElement Find(By locator) => Driver.FindElement(locator);

        protected void Click(By locator) => Find(locator).Click();

        protected void Type(By locator, string text)
        {
            var element = Find(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator) => Find(locator).Text;
    }
}
