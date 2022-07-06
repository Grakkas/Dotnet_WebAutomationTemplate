using OpenQA.Selenium;

namespace Dotnet_WebAutomationTemplate.Elements
{
    internal class BaseElements
    {
        public By Button_SignIn = By.ClassName("login");
        public By Button_LogOut = By.XPath("//a[@title='Log me out']");
        public By Input_CreateEmailx = By.Id("email_create");
    }
}
