using UITests.Drivers;

namespace UITests.Pages
{
  public static class PageFactory
  {
    public static HomePage HomePage => new(DriverManager.Driver);
    public static LoginPage LoginPage => new(DriverManager.Driver);
  }
}