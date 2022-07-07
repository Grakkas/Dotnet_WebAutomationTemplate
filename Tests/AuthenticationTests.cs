using Dotnet_WebAutomationTemplate.Pages;
using Dotnet_WebAutomationTemplate.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Dotnet_WebAutomationTemplate.Tests
{
    internal class AuthenticationTests
    {
        AuthenticationPage AuthenticationPage;

        [SetUp]
        public void SetUp()
        {
            AuthenticationPage = new AuthenticationPage();
        }

        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                AuthenticationPage.TakeScreenshot();
            }

            Assert.That(DriverFactory.Instance.CloseDriver(), Is.True);
            Assert.That(DriverFactory.Instance.CloseDriver(), Is.False);
        }

        [Test]
        public void LogInSuccessfully()
        {
            AuthenticationPage.GoToURL("http://automationpractice.com/index.php");
            AuthenticationPage.GoToAuthenticationPage();
            AuthenticationPage.FillLogIn("existent-user");
            Assert.That(AuthenticationPage.VerifyLogin("existent-user"), Is.True);
        }

        [Test]
        public void LogInWithInvalidEmail()
        {
            AuthenticationPage.GoToURL("http://automationpractice.com/index.php");
            AuthenticationPage.GoToAuthenticationPage();
            AuthenticationPage.FillLogIn("invalid-email-user");
            Assert.That(AuthenticationPage.VerifyLogin("invalid-email-user"), Is.True);
        }

        [Test]
        public void LogInWithEmptyEmail()
        {
            AuthenticationPage.GoToURL("http://automationpractice.com/index.php");
            AuthenticationPage.GoToAuthenticationPage();
            AuthenticationPage.FillLogIn("empty-email-user");
            Assert.That(AuthenticationPage.VerifyLogin("empty-email-user"), Is.True);
        }

        [Test]
        public void LogInWithInvalidPassword()
        {
            AuthenticationPage.GoToURL("http://automationpractice.com/index.php");
            AuthenticationPage.GoToAuthenticationPage();
            AuthenticationPage.FillLogIn("invalid-password-user");
            Assert.That(AuthenticationPage.VerifyLogin("invalid-password-user"), Is.True);
        }

        [Test]
        public void LogInWithEmptyPassword()
        {
            AuthenticationPage.GoToURL("http://automationpractice.com/index.php");
            AuthenticationPage.GoToAuthenticationPage();
            AuthenticationPage.FillLogIn("empty-password-user");
            Assert.That(AuthenticationPage.VerifyLogin("empty-password-user"), Is.True);
        }
    }
}
