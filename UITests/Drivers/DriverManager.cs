using OpenQA.Selenium;

namespace UITests.Drivers
{
  public static class DriverManager
  {
    private static readonly ThreadLocal<IWebDriver> _driver = new(() => WebDriverFactory.Create());

    public static IWebDriver Driver => _driver.Value!;

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
