using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace UITests.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            // Use a unique user data dir for each parallel run
            var tempDir = Path.Combine(Path.GetTempPath(), "selenium", Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            options.AddArgument($"--user-data-dir={tempDir}");
            options.AddArgument("--headless=new");


            return new ChromeDriver(options);
        }
    }
}
