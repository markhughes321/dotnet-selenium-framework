using NUnit.Framework;
using Allure.Net.Commons;

namespace UITests.Helpers
{
  [SetUpFixture]
  public class AllureSetup
  {
    [OneTimeSetUp]
    public void GlobalSetup()
    {
      Environment.SetEnvironmentVariable("ALLURE_CONFIG", "allureConfig.json");
      AllureLifecycle.Instance.CleanupResultDirectory();
    }
  }
}