using OpenQA.Selenium.Support.UI;
using UITests.Drivers;
using UITests.Helpers;
using UITests.Pages;
using NUnit.Framework;
using Allure.Net.Commons;
using OpenQA.Selenium;
using System;

namespace UITests.Tests
{
  /// <summary>
  /// Base class for all tests, providing setup and teardown logic.
  /// </summary>
  public abstract class BaseTest
  {
    protected WebDriverWait _wait;
    protected HomePage _homePage;

    /// <summary>
    /// Sets up the test environment by initializing the WebDriver, navigating to the base URL, and accepting cookies.
    /// </summary>
    [SetUp]
    public void Setup()
    {
      _wait = WaitHelper.GetDefaultWait(DriverManager.Driver);
      DriverManager.Driver.Navigate().GoToUrl(Constants.BaseUrl);
      _homePage = new HomePage(DriverManager.Driver);
      _homePage.AcceptCookiesIfVisible();
    }

    /// <summary>
    /// Cleans up after each test, capturing a screenshot on failure and quitting the WebDriver.
    /// </summary>
    [TearDown]
    public void Teardown()
    {
      // Check if the test failed
      if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
      {
        try
        {
          // Capture screenshot
          var screenshot = ((ITakesScreenshot)DriverManager.Driver).GetScreenshot();
          var screenshotBytes = screenshot.AsByteArray;
          // Attach screenshot to Allure report
          AllureApi.AddAttachment($"Screenshot on Failure - {TestContext.CurrentContext.Test.Name}", "image/png", screenshotBytes);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
        }
      }
      DriverManager.QuitDriver();
    }
  }
}