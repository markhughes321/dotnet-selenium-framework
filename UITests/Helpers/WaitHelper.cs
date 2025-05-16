using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UITests.Helpers
{
    public static class WaitHelper
    {
        public static WebDriverWait GetDefaultWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DefaultWaitSeconds));
        }
    }
}
