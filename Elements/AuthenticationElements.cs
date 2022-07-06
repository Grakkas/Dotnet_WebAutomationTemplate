using OpenQA.Selenium;

namespace Dotnet_WebAutomationTemplate.Elements
{
    internal class AuthenticationElements : BaseElements
    {
        public By Input_CreateEmail = By.Id("email_create");
        public By Button_CreateAccount = By.Id("SubmitCreate");

        public By Input_EmailAddress = By.Id("email");
        public By Input_Password = By.Id("passwd");
        public By Button_SubmitLogin = By.Id("SubmitLogin");

        public By Txt_PasswordRequired = By.XPath("//li[contains(.,'Password is required.')]");
        public By Txt_EmailRequired = By.XPath("//li[contains(.,'An email address required.')]");
        public By Txt_AuthenticationFailed = By.XPath("//li[contains(.,'Authentication failed.')]");
        public By Txt_InvalidEmail = By.XPath("//li[contains(.,'Invalid email address.')]");

        public By Button_ForgotPassword = By.XPath("//a[@title='Recover your forgotten password']");
    }
}
