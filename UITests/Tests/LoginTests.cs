
using UITests.Helpers;
using UITests.Pages;
using UITests.Components;

namespace UITests.Tests
{
    [TestFixture]
    [Category("Regression")]
    [Category("Login")]
    public class LoginTests : BaseTest
    {
        [Test]
        public void Login_Should_Show_LogOut_Button()
        {
            var header = new HeaderComponent(_driver);
            var loginPage = new LoginPage(_driver);

            header.OpenLoginModal();
            loginPage.Login(TestConfig.RyanairEmail, TestConfig.RyanairPassword);

            Assert.That(header.IsLoggedIn(), Is.True, "Login was not successful.");
        }
    }
}
