using UITests.Drivers;

namespace UITests.Pages
{
  /// <summary>
  /// Factory for creating page objects with the current WebDriver instance.
  /// Gets a new instance of the <see cref="HomePage"/> class.
  /// </summary>
  public static class PageFactory
  {
    public static HomePage HomePage => new(DriverManager.Driver);

    public static LoginPage LoginPage => new(DriverManager.Driver);
  }
}