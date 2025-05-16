using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-gpu");
            
            // options.AddArgument("--headless=new");
            return new ChromeDriver(options);
        }
    }
}
