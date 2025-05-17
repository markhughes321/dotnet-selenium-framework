using NUnit.Framework;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using Allure.Net.Commons;
using UITests.Helpers;
using UITests.Pages;
using UITests.Drivers;

namespace UITests.Tests
{
  [TestFixture]
  [AllureNUnit]
  [AllureSuite("Login")]
  [AllureSubSuite("Regression")]
  [AllureEpic("Authentication")]
  [AllureFeature("Login functionality")]
  [AllureStory("User logs in successfully")]
  [AllureOwner("Mark")]
  [AllureTag("Login", "CriticalPath")]
  [AllureSeverity(SeverityLevel.critical)]
  [AllureLink("RYANAIR-101", "https://jira.company.com/RYANAIR-101")]
  [AllureLink("BUG-202", "https://jira.company.com/BUG-202")]
  public class LoginTests : BaseTest
  {
    [Test]
    [Category("Smoke")]
    [AllureDescription("Validates that a user can successfully log into the Ryanair website using valid credentials.")]
    public void Login_Should_Show_LogOut_Button()
    {
      var homePage = PageFactory.HomePage;
      var loginPage = new LoginPage(DriverManager.Driver);
      AllureApi.Step("Open login modal", () => homePage.OpenLoginModal());
      AllureApi.Step("Login with valid credentials", () => loginPage.Login(TestConfig.RyanairEmail, TestConfig.RyanairPassword));
      AssertHelper.StepAssertIsTrue(homePage.IsLoggedIn(), "Logout button should be visible after login");
    }
  }
}