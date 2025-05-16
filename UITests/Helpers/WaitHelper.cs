using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITests.Helpers
{
  public static class WaitHelper
  {
    public static WebDriverWait GetDefaultWait(IWebDriver driver)
    {
      return new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DefaultWaitSeconds));
    }

    public static bool WaitUntilUrlContains(IWebDriver driver, string expectedSubstring, int timeoutSeconds = Constants.DefaultWaitSeconds)
    {
      var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
      return wait.Until(d => d.Url.Contains(expectedSubstring));
    }
  }
}
