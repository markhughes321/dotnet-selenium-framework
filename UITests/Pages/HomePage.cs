using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Helpers;

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
                var cookieButton = _wait.Until(d => d.FindElement(By.CssSelector("button[data-ref='cookie.accept-all']")));
                cookieButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Cookie popup not shown
            }
        }

        public void SelectOneWayTrip()
        {
            var label = _wait.Until(d =>
                d.FindElement(By.CssSelector("[data-ref='flight-search-trip-type__one-way-trip'] label"))
            );
            label.Click();
        }

        public void OpenDestinationInput()
        {
            var destinationInput = _wait.Until(d =>
                d.FindElement(By.CssSelector("div[data-ref='input-button__destination'] input")));
            destinationInput.Click();
        }

        public void SelectAnyDestination()
        {
            var anyDestination = _wait.Until(d => d.FindElement(By.CssSelector("[data-id='ANY']")));
            anyDestination.Click();
        }

        public void SelectFirstAvailableMonth()
        {
            var firstMonth = _wait.Until(d => d.FindElement(By.CssSelector("[data-ref^='flexible-dates__month-item']")));
            firstMonth.Click();
        }

        public void ApplyFlexibleDates()
        {
            var applyButton = _wait.Until(d => d.FindElement(By.CssSelector("button[data-ref='flexible-dates__cta-apply']")));
            applyButton.Click();
        }

        public void ClickSearch()
        {
            var searchButton = _wait.Until(d => d.FindElement(By.CssSelector("button[data-ref='flight-search-widget__cta']")));
            searchButton.Click();
        }
    }
}
