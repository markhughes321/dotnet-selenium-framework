using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Drivers;
using UITests.Helpers;
using UITests.Pages;

namespace UITests.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _driver = WebDriverFactory.Create();
            _wait = WaitHelper.GetDefaultWait(_driver);
            _driver.Navigate().GoToUrl(Constants.BaseUrl);

            _homePage = new HomePage(_driver);
            _homePage.AcceptCookiesIfVisible();
        }

        [TearDown]
        public void Teardown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
