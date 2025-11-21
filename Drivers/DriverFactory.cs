using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SaaSAutomationFramework.Drivers
{
    public static class DriverFactory
    {
        // ThreadStatic so each test can have its own driver if needed
        [ThreadStatic]
        private static IWebDriver _driver;

        // Public property to access the driver
        public static IWebDriver Driver
            => _driver ?? throw new NullReferenceException("WebDriver is not initialized. Call InitDriver() first.");

        // Initialize ChromeDriver
        public static void InitDriver()
        {
            var options = new ChromeOptions();
            // If you want headless later, uncomment next line:
            // options.AddArgument("--headless=new");
            options.AddArgument("--start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        // Quit and clean up
        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
