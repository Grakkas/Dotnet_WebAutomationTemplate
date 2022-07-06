using Dotnet_WebAutomationTemplate.Elements;
using Dotnet_WebAutomationTemplate.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;

namespace Dotnet_WebAutomationTemplate.Pages
{
    internal class BasePage
    {

        protected IWebDriver Driver = DriverFactory.Instance.Driver;
        protected IJavaScriptExecutor JSExecutor;
        protected Actions Actions;
        protected string? date = null;

        protected BaseElements BaseElements = new();

        public BasePage()
        {
            JSExecutor = (IJavaScriptExecutor)Driver;
            Actions = new Actions(Driver);
        }

        public void TakeScreenshot()
        {
            if (date == null)
            {
                date = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
            }
            int counter = 1;
            string ScreenshotPath = Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}/Screenshots/{TestContext.CurrentContext.Test.Name}_{date}").FullName;
            string FullScreenshotPath = $@"{ScreenshotPath}/Screenshot_{counter}.png";

            try
            {
                while (File.Exists($@"{FullScreenshotPath}"))
                {
                    counter++;
                    FullScreenshotPath = $@"{ScreenshotPath}/Screenshot_{counter}.png";
                }
            }
            catch (Exception) { }

            Driver.TakeScreenshot().SaveAsFile($@"{FullScreenshotPath}", ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment($@"{FullScreenshotPath}", $"Screenshot_{counter}");
        }

        public void GoToURL(string targetURL)
        {
            Driver.Url = targetURL;
            TakeScreenshot();
        }

        public void GoToAuthenticationPage()
        {
            GetElement(BaseElements.Button_SignIn, "BaseElements.Button_SignIn").Click();
            GetElement(BaseElements.Input_CreateEmailx, "BaseElements.Input_CreateEmail");
            TakeScreenshot();
        }

        public void ChangeTab(string target, bool byURL = true)
        {
            bool isFound = false;
            foreach (string windowHandle in DriverFactory.Instance.Driver.WindowHandles)
            {
                Driver.SwitchTo().Window(windowHandle);

                if (byURL)
                {
                    if (Driver.Url.ToLower().Contains(target.ToLower()))
                    {
                        isFound = true;
                        break;
                    }
                }
                else
                {
                    if (Driver.Title.ToLower().Contains(target))
                    {
                        isFound = true;
                        break;
                    }
                }
            }

            if (!isFound)
            {
                throw new NoSuchWindowException($"Could not find the browser window with the following information: {target}");
            }
        }

        protected DefaultWait<IWebDriver> Wait(int timeoutSec, string description)
        {
            DefaultWait<IWebDriver> wait = new(Driver);
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Timeout = TimeSpan.FromSeconds(timeoutSec);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Message = $@"Could not find element: {description}, within {timeoutSec} seconds";

            return wait;
        }

        protected IWebElement GetElement(By target, string description, int timeout = 10)
        {
            Wait(timeout, description).Until(ExpectedConditions.ElementToBeClickable(target));
            return Driver.FindElement(target);
        }

        protected SelectElement GetSelect(By target, string description, int timeout = 10)
        {
            Wait(timeout, description).Until(ExpectedConditions.ElementToBeClickable(target));
            return new SelectElement(Driver.FindElement(target));
        }

        protected void WaitInvisibility(By target, string description, int timeoutVisible, int timeoutInvisible)
        {
            try
            {
                Wait(timeoutVisible, description).Until(ExpectedConditions.ElementIsVisible(target));
                Wait(timeoutInvisible, description).Until(ExpectedConditions.InvisibilityOfElementLocated(target));
            }
            catch (Exception) { }
        }
    }
}
