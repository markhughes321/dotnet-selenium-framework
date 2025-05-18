using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using UITests.Helpers;
using UITests.Pages;
using UITests.Drivers;
namespace UITests.Tests
{
  [TestFixture]
  [AllureNUnit]
  [Parallelizable(ParallelScope.All)]
  [AllureSuite("Login")]
  [AllureSubSuite("Regression")]
  [AllureEpic("Authentication")]
  [AllureFeature("Login functionality")]
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
    [AllureStory("User logs in successfully")]
    public void Login_Successfully()
    {
      var homePage = PageFactory.HomePage;
      var loginPage = PageFactory.LoginPage;
      AllureApi.Step("Open login modal", () => homePage.OpenLoginModal());
      AllureApi.Step("Login with valid credentials", () => loginPage.Login(TestConfig.RyanairEmail, TestConfig.RyanairPassword));
      AssertHelper.StepAssert(() => homePage.IsLoggedIn(), "Logout button should be visible after login");
    }
    [Test]
    [Category("Regression")]
    [AllureDescription("Validates that a user receives an error message when attempting to log in with invalid credentials.")]
    [AllureStory("User fails to log in with invalid credentials")]
    [AllureTag("NegativeTest")]
    public void Login_InvalidCredentials()
    {
      var homePage = PageFactory.HomePage;
      var loginPage = PageFactory.LoginPage; // Use PageFactory instead of direct instantiation
      AllureApi.Step("Open login modal", () => homePage.OpenLoginModal());
      AllureApi.Step("Attempt login with invalid credentials", () => loginPage.Login("invalidEmail", "invalidPassword"));
      AssertHelper.StepAssert(() => loginPage.GetErrorMessage().Contains("Incorrect email address or password, 4 attempts left"), "Expected error message was displayed");
    }
  }
}