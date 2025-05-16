using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Helpers;

namespace UITests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = WaitHelper.GetDefaultWait(driver);
        }

        private IWebElement EmailInput => _wait.Until(
            driver => driver.FindElement(By.CssSelector("[data-ref='email_input'] input[type='email']")));

        private IWebElement PasswordInput => _wait.Until(
            driver => driver.FindElement(By.CssSelector("[data-ref='password_input'] input[type='password']")));

        private IWebElement LoginSubmitButton => _wait.Until(
            driver => driver.FindElement(By.CssSelector("[data-ref='login_cta'] button")));

        public void EnterEmailAndPassword(string email, string password)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void SubmitLogin()
        {
            LoginSubmitButton.Click();
        }

        public void Login(string email, string password)
        {
            var iframe = _wait.Until(d => d.FindElement(By.CssSelector("iframe[data-ref='kyc-iframe']")));
            _driver.SwitchTo().Frame(iframe);
            _wait.Until(d => EmailInput.Displayed && EmailInput.Enabled);
            EnterEmailAndPassword(email, password);
            SubmitLogin();
            _driver.SwitchTo().DefaultContent();
        }
    }
}
