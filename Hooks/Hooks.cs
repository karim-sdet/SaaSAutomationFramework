using TechTalk.SpecFlow;
using SaaSAutomationFramework.Drivers;

namespace SaaSAutomationFramework.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverFactory.InitDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverFactory.QuitDriver();
        }
    }
}
