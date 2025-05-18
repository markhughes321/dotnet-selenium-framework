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
  [AllureSuite("Flight Search")]
  [AllureSubSuite("Regression")]
  [AllureEpic("Booking Flow")]
  [AllureFeature("Flight Search")]
  [AllureStory("Search one-way trips to any destination")]
  [AllureOwner("Mark")]
  [AllureTag("FlightSearch", "CriticalPath")]
  [AllureSeverity(SeverityLevel.normal)]
  [AllureLink("RYANAIR-302", "https://jira.company.com/RYANAIR-302")]
  public class FlightSearchTests : BaseTest
  {
    [Test, Category("Smoke")]
    [AllureDescription("Validate that a user can search for a one-way trip with flexible dates and reach the fare-finder results page.")]
    public void Search_OneWayTrip_ToAnyDestination()
    {
      var homePage = PageFactory.HomePage;
      AllureApi.Step("Select one-way trip", () => homePage.SelectOneWayTrip());
      AllureApi.Step("Open destination input", () => homePage.OpenDestinationInput());
      AllureApi.Step("Select 'Any destination'", () => homePage.SelectAnyDestination());
      AllureApi.Step("Select first available month", () => homePage.SelectFirstAvailableMonth());
      AllureApi.Step("Apply flexible dates", () => homePage.ApplyFlexibleDates());
      AllureApi.Step("Click search", () => homePage.ClickSearch());
      AssertHelper.StepAssert(() => DriverManager.Driver.Url.Contains("fare-finder"), "User is navigated to the fare-finder page", Constants.DefaultWaitSeconds);
    }
  }
}