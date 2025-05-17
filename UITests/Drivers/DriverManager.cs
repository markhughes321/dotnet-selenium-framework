using OpenQA.Selenium;

namespace UITests.Drivers
{
    /// <summary>
    /// Manages the WebDriver instance for thread-safe test execution.
    /// </summary>
    public static class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> _driver = new(() => WebDriverFactory.Create());

        /// <summary>
        /// Gets the current WebDriver instance.
        /// </summary>
        public static IWebDriver Driver => _driver.Value!;

        /// <summary>
        /// Quits and disposes the WebDriver instance if it exists.
        /// </summary>
        public static void QuitDriver()
        {
            if (_driver.IsValueCreated && _driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
            }
        }
    }
}