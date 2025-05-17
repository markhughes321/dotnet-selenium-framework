using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Allure.Net.Commons;

namespace UITests.Helpers
{
    public static class AssertHelper
    {
        public static void StepAssertIsTrue(bool condition, string stepDescription)
        {
            AllureApi.Step(stepDescription, () =>
            {
                Assert.That(condition, Is.True, stepDescription);
            });
        }

        public static void StepAssertElementVisible(IWebElement element, string stepDescription)
        {
            AllureApi.Step(stepDescription, () =>
            {
                Assert.That(element.Displayed, Is.True, stepDescription);
            });
        }

        public static void StepAssertUrlContains(IWebDriver driver, string expectedSubstring, string stepDescription)
        {
            AllureApi.Step(stepDescription, () =>
            {
                Assert.That(driver.Url.Contains(expectedSubstring), Is.True, stepDescription);
            });
        }

        public static void StepAssertUrlContainsAfterWait(IWebDriver driver, string expectedSubstring, string stepDescription, int timeoutSeconds = Constants.DefaultWaitSeconds)
        {
            AllureApi.Step(stepDescription, () =>
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                bool result = wait.Until(d => d.Url.Contains(expectedSubstring));
                Assert.That(result, Is.True, stepDescription);
            });
        }
    }
}
