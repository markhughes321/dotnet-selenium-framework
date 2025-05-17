using OpenQA.Selenium.Support.UI;
using UITests.Drivers;
using UITests.Helpers;
using UITests.Pages;
using NUnit.Framework;

namespace UITests.Tests
{
  public abstract class BaseTest
  {
    protected WebDriverWait _wait;
    protected HomePage _homePage;

    [SetUp]
    public void Setup()
    {
      _wait = WaitHelper.GetDefaultWait(DriverManager.Driver);
      DriverManager.Driver.Navigate().GoToUrl(Constants.BaseUrl);
      _homePage = new HomePage(DriverManager.Driver);
      _homePage.AcceptCookiesIfVisible();
    }

    [TearDown]
    public void Teardown()
    {
      DriverManager.QuitDriver();
    }
  }
}