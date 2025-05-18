using UITests.Drivers;
namespace UITests.Pages
{
  /// <summary>
  /// Factory for creating page objects with the current WebDriver instance.
  /// Provides a centralized mechanism to instantiate page objects, ensuring consistency
  /// and simplifying maintenance across tests.
  /// </summary>
  public static class PageFactory
  {
    public static HomePage HomePage => new(DriverManager.Driver);
    public static LoginPage LoginPage => new(DriverManager.Driver);
  }
}