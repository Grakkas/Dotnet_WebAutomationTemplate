using Dotnet_WebAutomationTemplate.Pages;
using Dotnet_WebAutomationTemplate.Utils;
using NUnit.Framework;

namespace Dotnet_WebAutomationTemplate.Tests
{
    public class DriverFactoryTests
    {
        private BasePage BasePage;

        [SetUp]
        public void SetUp()
        {
            BasePage = new BasePage();
        }

        [TearDown]
        public void TearDown()
        {
            Assert.That(DriverFactory.Instance.CloseDriver(), Is.True);
            Assert.That(DriverFactory.Instance.CloseDriver(), Is.False);
        }

        [Test]
        public void VerifyIfBrowserIsWorkingProperly()
        {
            BasePage.GoToURL("http://automationpractice.com/index.php");
        }
    }
}