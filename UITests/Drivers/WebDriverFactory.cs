using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            var tempUserDataDir = Path.Combine(Path.GetTempPath(), "selenium", Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempUserDataDir);
            options.AddArgument($"--user-data-dir={tempUserDataDir}");

            return new ChromeDriver(options);
        }
    }
}
