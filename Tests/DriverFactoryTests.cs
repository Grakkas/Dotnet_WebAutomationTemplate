using Dotnet_WebAutomationTemplate.Utils;
using NUnit.Framework;

namespace Dotnet_WebAutomationTemplate.Tests
{
    public class DriverFactoryTests
    {

        [Test]
        public void VerifyIfBrowserIsWorkingProperly()
        {
            DriverFactory.Instance.Driver.Url = "http://automationpractice.com/index.php";

            //Verifys if the browser was closed
            Assert.That(DriverFactory.Instance.CloseDriver(), Is.True);

            //Verify if the browser was already closed
            Assert.That(DriverFactory.Instance.CloseDriver(), Is.False);
        }
    }
}