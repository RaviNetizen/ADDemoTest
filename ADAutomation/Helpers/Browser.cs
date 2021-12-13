using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace loginPage.Helpers
{
    class Browser
    {
        static IWebDriver _driver;
        public static IWebDriver Startbrowser(String browserName, string url)

        {
            if (browserName.Equals("firefox"))
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.FirefoxBinaryPath = @"C:\Users\ravi.yarkareddy2\AppData\Local\Mozilla Firefox\firefox.exe";
                _driver = new FirefoxDriver(service);
                _driver.Manage().Window.Maximize();
                _driver.Manage().Cookies.DeleteAllCookies();
            }
            else if (browserName.Equals("chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("disable-popup-blocking", "true");
                _driver = new ChromeDriver(options);
                _driver.Manage().Window.Maximize();
                _driver.Manage().Cookies.DeleteAllCookies();
            }

            _driver.Navigate().GoToUrl(url);
            return _driver;
        }
    }
}
