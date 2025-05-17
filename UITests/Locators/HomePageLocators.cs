using OpenQA.Selenium;

namespace UITests.Locators
{
  public static class HomePageLocators
  {
    public static readonly By CookieAcceptButton = By.CssSelector("button[data-ref='cookie.accept-all']");
    public static readonly By OneWayTripLabel = By.CssSelector("[data-ref='flight-search-trip-type__one-way-trip'] label");
    public static readonly By DestinationInput = By.CssSelector("div[data-ref='input-button__destination'] input");
    public static readonly By AnyDestinationOption = By.CssSelector("[data-id='ANY']");
    public static readonly By FirstAvailableMonth = By.CssSelector("[data-ref^='flexible-dates__month-item']");
    public static readonly By FlexibleDatesApplyButton = By.CssSelector("button[data-ref='flexible-dates__cta-apply']");
    public static readonly By SearchButton = By.CssSelector("button[data-ref='flight-search-widget__cta']");
    public static readonly By LoginButton = By.CssSelector("ry-log-in-button button");
    public static readonly By LogoutButton = By.CssSelector("ry-log-out-button button");
  }
}