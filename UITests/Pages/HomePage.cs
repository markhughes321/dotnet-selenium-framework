using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Helpers;
using UITests.Locators;

namespace UITests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = WaitHelper.GetDefaultWait(driver);
        }

        public void AcceptCookiesIfVisible()
        {
            try
            {
                var cookieButton = _wait.Until(d => d.FindElement(HomePageLocators.CookieAcceptButton));
                cookieButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Cookie popup not shown
            }
        }

        public void SelectOneWayTrip()
        {
            var label = _wait.Until(d => d.FindElement(HomePageLocators.OneWayTripLabel));
            label.Click();
        }

        public void OpenDestinationInput()
        {
            var destinationInput = _wait.Until(d => d.FindElement(HomePageLocators.DestinationInput));
            destinationInput.Click();
        }

        public void SelectAnyDestination()
        {
            var anyDestination = _wait.Until(d => d.FindElement(HomePageLocators.AnyDestinationOption));
            anyDestination.Click();
        }

        public void SelectFirstAvailableMonth()
        {
            var firstMonth = _wait.Until(d => d.FindElement(HomePageLocators.FirstAvailableMonth));
            firstMonth.Click();
        }

        public void ApplyFlexibleDates()
        {
            var applyButton = _wait.Until(d => d.FindElement(HomePageLocators.FlexibleDatesApplyButton));
            applyButton.Click();
        }

        public void ClickSearch()
        {
            var searchButton = _wait.Until(d => d.FindElement(HomePageLocators.SearchButton));
            searchButton.Click();
        }

        public void OpenLoginModal()
        {
            var loginBtn = _wait.Until(d => d.FindElement(HomePageLocators.LoginButton));
            loginBtn.Click();
        }

        public bool IsLoggedIn()
        {
            return _wait.Until(d => d.FindElement(HomePageLocators.LogoutButton)).Displayed;
        }
    }
}