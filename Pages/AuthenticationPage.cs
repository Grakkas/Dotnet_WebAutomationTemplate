using Dotnet_WebAutomationTemplate.Elements;
using Dotnet_WebAutomationTemplate.Utils;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Dotnet_WebAutomationTemplate.Pages
{
    internal class AuthenticationPage : BasePage
    {
        private JObject AuthenticationData { get; set; }
        private AuthenticationElements AuthenticationElements = new AuthenticationElements();

        public AuthenticationPage()
        {
            AuthenticationData = JObject.Parse(File.ReadAllText($@"../../../Data/AuthenticationData.json"));
        }

        public void FillLogIn(string AuthenticationTarget)
        {
            GetElement(AuthenticationElements.Input_EmailAddress, "AuthenticationElements.Input_EmailAddress").SendKeys(AuthenticationData[AuthenticationTarget]["personal-information"]["email"].ToString());
            GetElement(AuthenticationElements.Input_Password, "AuthenticationElements.Input_Password").SendKeys(AuthenticationData[AuthenticationTarget]["personal-information"]["password"].ToString());
            TakeScreenshot();
        }

        public bool VerifyLogin(string AuthenticationTarget)
        {
            GetElement(AuthenticationElements.Button_SubmitLogin, "AuthenticationElements.Button_SubmitLogin").Click();

            if (AuthenticationTarget.ToLower().Contains("existent"))
            {
                GetElement(BaseElements.Button_LogOut, "BaseElements.Button_LogOut");
                TakeScreenshot();
                return true;
            }
            else if (AuthenticationTarget.ToLower().Contains("invalid-email"))
            {
                GetElement(AuthenticationElements.Txt_InvalidEmail, "AuthenticationElements.Div_InvalidEmail");
                TakeScreenshot();
                return true;
            }
            else if (AuthenticationTarget.ToLower().Contains("empty-email-user"))
            {
                GetElement(AuthenticationElements.Txt_EmailRequired, "AuthenticationElements.Txt_EmailRequired");
                TakeScreenshot();
                return true;
            }
            else if (AuthenticationTarget.ToLower().Contains("invalid-password-user"))
            {
                GetElement(AuthenticationElements.Txt_AuthenticationFailed, "AuthenticationElements.Txt_AuthenticationFailed");
                TakeScreenshot();
                return true;
            }
            else if (AuthenticationTarget.ToLower().Contains("empty-password-user"))
            {
                GetElement(AuthenticationElements.Txt_PasswordRequired, "AuthenticationElements.Txt_PasswordRequired");
                TakeScreenshot();
                return true;
            }
            else
            {
                TakeScreenshot();
                return false;
            }
        }
    }
}
