using NUnit.Framework;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using Allure.Net.Commons;
using UITests.Components;
using UITests.Helpers;
using UITests.Pages;

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
    [AllureDescription("This test validates that a user can successfully log into the Ryanair website using valid credentials.")]
    public void Login_Should_Show_LogOut_Button()
    {
      var header = new HeaderComponent(_driver);
      var loginPage = new LoginPage(_driver);

      AllureApi.Step("Open login modal", () => header.OpenLoginModal());
      AllureApi.Step("Login with valid credentials", () =>
          loginPage.Login(TestConfig.RyanairEmail, TestConfig.RyanairPassword));
      AllureApi.Step("Verify logout button is visible", () =>
          Assert.That(header.IsLoggedIn(), Is.True));
    }
  }
}
