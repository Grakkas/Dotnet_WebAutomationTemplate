using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Dotnet_WebAutomationTemplate.Utils
{
    internal class DriverFactory
    {

        private static DriverFactory? _Instance;
        public static DriverFactory Instance
        {
            get
            {
                return _Instance ??= new DriverFactory();
            }
        }

        private IWebDriver? _Driver;
        public IWebDriver Driver
        {
            get
            {
                if (_Driver == null)
                {
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _Driver = new ChromeDriver();
                }
                return _Driver;
            }
        }

        public bool CloseDriver()
        {
            if (_Driver != null)
            {
                _Driver.Quit();
                _Driver.Dispose();
                _Driver = null;
                return true;
            }
            return false;
        }
    }
}