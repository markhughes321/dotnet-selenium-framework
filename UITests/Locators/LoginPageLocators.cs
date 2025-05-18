// File: ./UITests/Locators/LoginPageLocators.cs
using OpenQA.Selenium;

namespace UITests.Locators
{
  public static class LoginPageLocators
  {
    public static readonly By KycIframe = By.CssSelector("iframe[data-ref='kyc-iframe']");
    public static readonly By EmailInput = By.CssSelector("[data-ref='email_input'] input[type='email']");
    public static readonly By PasswordInput = By.CssSelector("[data-ref='password_input'] input[type='password']");
    public static readonly By LoginSubmitButton = By.CssSelector("[data-ref='login_cta'] button");
    public static readonly By ErrorMessage = By.CssSelector("ry-input-d[name='password'] span[class='body-l-lg body-l-sm _error']");
  }
}