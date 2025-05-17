using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Helpers;
using UITests.Locators;

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

        private IWebElement EmailInput => _wait.Until(driver => driver.FindElement(LoginPageLocators.EmailInput));
        private IWebElement PasswordInput => _wait.Until(driver => driver.FindElement(LoginPageLocators.PasswordInput));
        private IWebElement LoginSubmitButton => _wait.Until(driver => driver.FindElement(LoginPageLocators.LoginSubmitButton));

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
            var iframe = _wait.Until(d => d.FindElement(LoginPageLocators.KycIframe));
            _driver.SwitchTo().Frame(iframe);
            _wait.Until(d => EmailInput.Displayed && EmailInput.Enabled);
            EnterEmailAndPassword(email, password);
            SubmitLogin();
            _driver.SwitchTo().DefaultContent();
        }
    }
}