using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using UITests.Helpers;

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
    [Test]
    [AllureDescription("Verifies that a user can search for a one-way trip with flexible dates and reach the fare-finder results page.")]
    public void Search_OneWayTrip_ToAnyDestination()
    {
      AllureApi.Step("Select one-way trip", () => _homePage.SelectOneWayTrip());
      AllureApi.Step("Open destination input", () => _homePage.OpenDestinationInput());
      AllureApi.Step("Select 'Any destination'", () => _homePage.SelectAnyDestination());
      AllureApi.Step("Select first available month", () => _homePage.SelectFirstAvailableMonth());
      AllureApi.Step("Apply flexible dates", () => _homePage.ApplyFlexibleDates());
      AllureApi.Step("Click search", () => _homePage.ClickSearch());

      AllureApi.Step("Wait for fare-finder page to load", () =>
      {
        bool isOnFareFinder = WaitHelper.WaitUntilUrlContains(_driver, "fare-finder");
        Assert.That(isOnFareFinder, Is.True, "Expected to be on fare-finder page.");
      });
    }
  }
}
