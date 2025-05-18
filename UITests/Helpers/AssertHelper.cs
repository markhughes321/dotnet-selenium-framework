using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Allure.Net.Commons;
using UITests.Drivers; // Added to resolve DriverManager

namespace UITests.Helpers
{
    public static class AssertHelper
    {
        public static void StepAssert(Func<bool> condition, string stepDescription, int? timeoutSeconds = null)
        {
            AllureApi.Step(stepDescription, () =>
            {
                if (timeoutSeconds.HasValue)
                {
                    var wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(timeoutSeconds.Value));
                    bool result = wait.Until(_ => condition());
                    Assert.That(result, Is.True, stepDescription);
                }
                else
                {
                    Assert.That(condition(), Is.True, stepDescription);
                }
            });
        }

        public static void StepAssertEqual<T>(T actual, T expected, string stepDescription)
        {
            AllureApi.Step(stepDescription, () =>
            {
                Assert.That(actual, Is.EqualTo(expected), stepDescription);
            });
        }
    }
}