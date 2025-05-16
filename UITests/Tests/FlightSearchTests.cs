// File: UITests/Tests/FlightSearchTests.cs
using NUnit.Framework;
using UITests.Pages;

namespace UITests.Tests
{
    [TestFixture]
    [Category("Regression")]
    [Category("FlightSearch")]
    public class FlightSearchTests : BaseTest
    {
        [Test]
        public void Search_OneWayTrip_ToAnyDestination()
        {
            _homePage.SelectOneWayTrip();
            _homePage.OpenDestinationInput();
            _homePage.SelectAnyDestination();
            _homePage.SelectFirstAvailableMonth();
            _homePage.ApplyFlexibleDates();
            _homePage.ClickSearch();

            _wait.Until(driver => driver.Url.Contains("fare-finder"));
            Assert.That(_driver.Url, Does.Contain("fare-finder"), "Expected to be on fare-finder page.");
        }
    }
}
