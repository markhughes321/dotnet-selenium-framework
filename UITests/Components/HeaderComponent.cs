using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Helpers;

namespace UITests.Components
{
    public class HeaderComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HeaderComponent(IWebDriver driver)
        {
            _driver = driver;
            _wait = WaitHelper.GetDefaultWait(driver);
        }

        public void OpenLoginModal()
        {
            var loginBtn = _wait.Until(d => d.FindElement(By.CssSelector("ry-log-in-button button")));
            loginBtn.Click();
        }

        public bool IsLoggedIn()
        {
            return _wait.Until(d => d.FindElement(By.CssSelector("ry-log-out-button button"))).Displayed;
        }
    }
}
