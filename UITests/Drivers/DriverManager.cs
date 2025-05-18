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
    /// Gets the current WebDriver instance, creating a new one if necessary.
    /// </summary>
    public static IWebDriver Driver
    {
      get
      {
        if (!_driver.IsValueCreated || _driver.Value == null)
        {
          _driver.Value = WebDriverFactory.Create();
        }
        return _driver.Value;
      }
    }

    /// <summary>
    /// Initializes a new WebDriver instance, disposing the existing one if necessary.
    /// </summary>
    public static void InitializeDriver()
    {
      if (_driver.IsValueCreated && _driver.Value != null)
      {
        try
        {
          _driver.Value.Quit();
          _driver.Value.Dispose();
        }
        catch
        {
          // Ignore exceptions during cleanup
        }
      }
      _driver.Value = WebDriverFactory.Create();
    }

    /// <summary>
    /// Quits and disposes the WebDriver instance if it exists.
    /// </summary>
    public static void QuitDriver()
    {
      if (_driver.IsValueCreated && _driver.Value != null)
      {
        try
        {
          _driver.Value.Quit();
          _driver.Value.Dispose();
        }
        catch
        {
          // Ignore exceptions during cleanup
        }
      }
    }
  }
}